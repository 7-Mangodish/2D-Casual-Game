using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool isDown;
    private Vector3 beginPos;
    [SerializeField] float speed;
    [SerializeField] private float timeStay;
    [SerializeField] private float distance;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        beginPos = transform.position;
        Physics2D.IgnoreLayerCollision(11, 3, true);

        speed = 5;
        distance = 10;
        timeStay = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDown)
        {
            Invoke(nameof(turnOff), timeStay);
        }
        else
            Invoke(nameof(turnOn), timeStay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
            isDown = true;

        }
    }

    void turnOff()
    {
        anim.Play("Off");
        this.transform.position = new Vector3(this.transform.position.x,
            this.transform.position.y - speed * Time.deltaTime, this.transform.position.z);
        if(Vector3.Distance(beginPos, this.transform.position) >= distance)
        {
            isDown = false;
        }
    }

    void turnOn()
    {
        anim.Play("On");
        this.transform.position = Vector3.MoveTowards(this.transform.position, beginPos, speed * Time.deltaTime);

    }
}
