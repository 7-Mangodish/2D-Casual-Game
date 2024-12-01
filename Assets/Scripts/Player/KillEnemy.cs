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
            FindObjectOfType<AudioManager>().PlaySfx("HitEnemy");

            //Debug.Log(other.gameObject);
            EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
            playerRigid.velocity = Vector2.up * bounce;
            if (enemy == null)
                Debug.Log("Cant find ");
            else
                enemy.EnemyDied();
        }
    }
}
