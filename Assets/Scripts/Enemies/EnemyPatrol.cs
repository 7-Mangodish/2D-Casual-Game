using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] protected  Transform[] points;
    [SerializeField] protected float speedPatrol;
    protected float timeIdle;
    protected float timeDuration;
    protected int cntPoints;
    protected int targetPoint;

    protected Animator anim;
    protected string curState ;

    public string CurState
    {
        get { return this.curState; }
        set { this.curState = value; }
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        cntPoints = points.GetLength(0);
        targetPoint = 0;
        speedPatrol = 2;
        timeIdle = 2;
        timeDuration = 0f;

        anim.Play("Idle");
        curState = "Idle";
        Physics2D.IgnoreLayerCollision(8, 8, true) ;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected virtual void Move()
    {

        if (Vector3.Distance(this.transform.position, points[targetPoint].position) < 1.5f)
        {
            timeDuration += Time.deltaTime;
            changeState("Idle");
            Debug.Log("Idle");

            if (timeDuration > timeIdle)
            {
                timeDuration = 0;
                targetPoint++;
                Flip();
                changeState("Run");
                if (targetPoint >= cntPoints)
                    targetPoint = 0;
            }
        }
        else
        {

            this.transform.position = Vector3.MoveTowards(this.transform.position,
            points[targetPoint].position, speedPatrol * Time.deltaTime);
        }
    }
    protected void Flip()
    {
        Vector3 direct = this.transform.localScale;
        this.transform.localScale = new Vector3(direct.x * -1, direct.y, direct.z);
    }
    protected void changeState(string state)
    {
        if (curState == state)
            return;
        curState = state;
        anim.Play(curState);
    }
}
