using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMakeDame : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Make Damage");
            HealthSystem healthSystem = col.gameObject.GetComponent<HealthSystem>();
            if(healthSystem != null)
            {
                healthSystem.TakeDame();
            }
        }
    }
}
