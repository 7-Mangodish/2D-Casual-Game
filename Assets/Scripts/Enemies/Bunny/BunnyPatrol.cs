using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyPatrol : MonoBehaviour
{

    // Start is called before the first frame update
    private int direct;
    [SerializeField] private float jumpPower;
    [SerializeField] private Transform[] listPoint;

    private int targetPoint;
    private float speedPatrol;
    
    private Rigidbody2D rb;
    private float timeIdle;
    private float  timeDuration;

    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        targetPoint = 0;
        speedPatrol = 4f;

        timeDuration = 0f;
        timeIdle = 2f;

        jumpPower = 18f;
        Debug.Log(Vector3.Distance(listPoint[0].position, listPoint[1].position) / 2);

    }
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (Vector3.Distance(this.transform.position, listPoint[targetPoint].position) ==9f)
        {
            rb.velocity = Vector3.up * jumpPower;
            Debug.Log("Jump");
        }
        if (Vector3.Distance(this.transform.position, listPoint[targetPoint].position) >= 1.5f) {
            this.transform.position =
                Vector3.MoveTowards(this.transform.position, listPoint[targetPoint].position, speedPatrol * Time.deltaTime);

        }
        else
        {
            timeDuration += Time.deltaTime;
            if(timeDuration > timeIdle)
            {
                Flip();
                targetPoint++;
                if (targetPoint >= listPoint.Length)
                    targetPoint = 0;
                timeDuration = 0;
            }
        }
    }
    void Flip()
    {
        Vector3 direct = this.transform.localScale;
        this.transform.localScale = new Vector3(direct.x * -1, direct.y, direct.z);
    }

}
