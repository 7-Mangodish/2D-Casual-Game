using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D col;
    private Animator anim;
    private string curAnim;
    private int curState;
    private int newState;


    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();

        curAnim = "Idle1";
        newState = 1;
        curState = 1;
        StartCoroutine("State1");
    }

    // Update is called once per frame
    void Update()
    {
        if (curState == newState)
            return;
        else
        {
            curState = newState;
            StartCoroutine("State" + curState);
        }
    }

    private IEnumerator State1()
    {
        this.gameObject.tag = "Trap";
        ChangeAnim("SpikeOut");
        yield return new WaitForSeconds(0.5f);
        ChangeAnim("Idle1");
        yield return new WaitForSeconds(5f);
        newState =2;
    }

    private IEnumerator State2()
    {
        this.gameObject.tag = "Enemy";
        ChangeAnim("SpikeIn");
        yield return new WaitForSeconds(0.5f);
        ChangeAnim("Idle2");
        yield return new WaitForSeconds(5f);
        newState = 1;
    }
    private void ChangeAnim(string newAnim)
    {
        if (curAnim == newAnim)
            return;
        curAnim = newAnim;
        anim.Play(curAnim);

    }

    // Muc dich: Do class KillEnemy se ha guc quai co tag la enemy nen doi thanh trap
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(this.gameObject.CompareTag("Trap") && col.gameObject.CompareTag("Player"))
        {
            HealthSystem health = col.gameObject.GetComponent<HealthSystem>();
            health.TakeDame();
        }
    }
}
