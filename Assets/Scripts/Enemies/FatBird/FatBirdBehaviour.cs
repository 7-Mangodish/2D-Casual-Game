using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBirdBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private bool canFall;
    private Vector3 beginPosition;
    private Animator anim;
    private float flyPower;

    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private LayerMask checkPlayer;
    public bool CanFall
    {
        get { return this.canFall; }
        set { this.canFall = value; }
    }
    void Start()
    {
        beginPosition = this.transform.position;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        canFall = false;
        flyPower = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayer() && Vector3.Distance(this.transform.position, beginPosition) < 2f)
            canFall = true;
        if (canFall)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 6;
            anim.Play("Fall");
        }
        else
        {
            anim.Play("Idle");
            this.transform.position = Vector3.MoveTowards(this.transform.position, beginPosition, 
                flyPower * Time.deltaTime);
        }
    }

    private bool IsPlayer()
    {
        return Physics2D.OverlapBox(bc.bounds.center, bc.bounds.size, 0, checkPlayer);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Gr1");
        if (other.gameObject.CompareTag("Ground"))
        {
            anim.Play("Ground");
            canFall = false;
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
