using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigid;
    private float bounce = 15f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Jump on Enemy");
            MoveMent player = playerRigid.gameObject.GetComponent<MoveMent>();
            player.CntJump = 1;
            AudioManager.Instance.PlaySfx("HitEnemy");

            //Debug.Log(other.gameObject);
            EnemyDie enemyDie = other.gameObject.GetComponent<EnemyDie>();
            playerRigid.velocity = Vector2.up * bounce;
            if (enemyDie == null )
                Debug.Log("Cant find ");
            else
            {
                enemyDie.Died();
            }
        }
    }
}
