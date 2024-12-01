using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private int direction;
    private float wallHitTime;
    private float timeIdle;

    [SerializeField] private float speedPatrol;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundlayer;

    private Animator anim;
    private string curState;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(9, 9, true);
        direction = 1;
        timeIdle = 3f;
        curState = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }



    void Patrol()
    {
        if (!isHitWall())
        {
            rb.velocity = Vector2.left * direction * speedPatrol;
            ChangeState("Run");
        }
        else
        {
            // Animator
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                ChangeState("HitWall");
            //Idle
            /*
             Lay thong tin ve state hien tai co layer 0 (mac dinh), kiem tra xem no co phai la HitWall Hay khong
                va da chay het hay chua
            normalizedtime: tra ve thoi gian cua animation chuan hoa ve (0->1) 1.0 tuc la da ket thuc
             */
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("HitWall") 
                && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                ChangeState("Idle");
                //Debug.Log("End");
            }

            wallHitTime += Time.deltaTime;

            if (wallHitTime > timeIdle)
            {
                Flip();
                wallHitTime = 0;
            }
            // Change Direction
        }
    }

    bool isHitWall()
    {
        return Physics2D.Raycast(this.transform.position, Vector2.left * direction, groundCheckDistance, groundlayer);
    }

    void Flip()
    {
        Vector3 direct = this.transform.localScale;
        direction *= -1;
        this.transform.localScale = new Vector3(direct.x * -1, direct.y, direct.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(this.transform.position, new Vector3(transform.position.x + groundCheckDistance,
            transform.position.y, transform.position.z));
    }

    void ChangeState(string state)
    {
        if (curState == state)
            return;
        curState = state;
        anim.Play(curState);

    }

}
