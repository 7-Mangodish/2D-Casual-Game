using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private BoxCollider2D []bc;
    private Rigidbody2D rb;
    private float timeDied;
    private Animator anim;
    [SerializeField] private float angleDie;
    void Start()
    {
        bc = GetComponents<BoxCollider2D> ();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator> ();
        timeDied = 1f;
        angleDie = 2000f;
    }

    void Update()
    {
    }

    public void EnemyDied()
    {
        //if(rb.bodyType == RigidbodyType2D.Static)
        //{
        //    rb.bodyType = RigidbodyType2D.Dynamic;
        //    rb.mass = 1000;
        //    rb.gravityScale = 4;
        //}

        //anim.Play("Die");

        //rb.velocity = new Vector2(4, 10);
        //this.transform.RotateAround(this.transform.position, Vector3.back, angleDie*Time.deltaTime);
        //foreach(BoxCollider2D c in bc)
        //{
        //    c.enabled = false;
        //}
        //Invoke("StopAnimation", 0.1f);
        //Invoke("EnemyDisAppear", timeDied);


    }

    private void StopAnimation()
    {
        anim.enabled = false;
    }
    private void EnemyDisAppear()
    {
        this.gameObject.SetActive(false);
    }
}
