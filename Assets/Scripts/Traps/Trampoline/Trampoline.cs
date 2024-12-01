using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private float force;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        force = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
            MoveMent playerMove = collision.gameObject.GetComponent<MoveMent>();
            if(player != null)
            {
                FindObjectOfType<AudioManager>().PlaySfx("Trampoline");
                player.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                anim.SetTrigger("Jump");
                playerMove.CntJump = 1;
            }
        }
    }
}
