using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject pfObject;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject pfItem;
    private Animator anim;
    private float force;

    void Start()
    {
        force = 10;
        anim = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(9, 8, true);
    }

    void Update()
    {
        if (health == 0)
        {
            //Destroy(this.gameObject);
            //Debug.Log("Die");
            //Debug.Log(new Vector2(parent.transform.position.x,parent.transform.position.y));
            Instantiate(pfObject, new Vector2(this.transform.parent.position.x,
            this.transform.parent.position.y + 1), Quaternion.identity);

            Destroy(parent.gameObject);
            AudioManager.Instance.PlaySfx("BlockBreak");
            if(pfItem != null)
            {
                Instantiate(pfItem, this.transform.parent.position, Quaternion.identity);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
            anim.Play("Hit");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            health -= 1;
            //Debug.Log(health);
        }
    }

}
