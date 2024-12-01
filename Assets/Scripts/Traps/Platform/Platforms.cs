using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float speedPatrol;
    private Animator anim;
    private int targetPoint;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        speedPatrol = 2;
        Move();
        anim.SetTrigger("Active");
    }

    private void Move()
    {
        if (Vector2.Distance(this.transform.position, points[targetPoint].position) < 0.5f)
        {
            targetPoint++;
            if (targetPoint >= points.Length)
                targetPoint = 0;
        }
        else
            this.transform.position = Vector2.MoveTowards(this.transform.position, points[targetPoint].position,
                        speedPatrol * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
