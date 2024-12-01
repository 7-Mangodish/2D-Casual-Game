using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ChameleonBehaviour :  MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private LayerMask playerLayer;
    private EnemyPatrol enemyPatrol;
    private float cooldown;
    private float duration;
    private Vector3 direct;

    private Animator anim;
    void Start()
    {
        enemyPatrol = GetComponent<EnemyPatrol>();
        anim = GetComponent<Animator>();
        cooldown = 2;
        duration = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        duration += Time.deltaTime;
        if (PlayerInSight())
        {
            if(duration > cooldown)
            {
                duration = 0;
                anim.SetTrigger("trigAttack");
                Invoke(nameof(returnCurstate), 0.5f);
            }
        }
        enemyPatrol.enabled = !PlayerInSight();
    }

    private RaycastHit2D PlayerInSight()
    {
        direct = Vector3.left * this.transform.localScale.x;
        return Physics2D.Raycast(this.transform.position, direct, distance, playerLayer);
    }
    private void damagePlayer()
    {
        RaycastHit2D hit = PlayerInSight();
        if(hit)
        {
            HealthSystem health = hit.collider.gameObject.GetComponent<HealthSystem>();
            //Debug.Log("Find");
            health.TakeDame();
        }
    }

    // Do khi thuc hien trigger xong, Component EnemyPatrol ko the thuc hien tiep curState
    // nguyen nhan la do ham changestate() --> Khong thuc hien do return 2 trang thai giong nhau
    private void returnCurstate()
    {
        anim.Play(enemyPatrol.CurState);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        direct = Vector3.left * this.transform.localScale.x;
        Gizmos.DrawLine(this.transform.position, new Vector2(transform.position.x + distance * direct.x, 
            transform.position.y));
    }
}
