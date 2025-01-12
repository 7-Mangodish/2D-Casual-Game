using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player")){
            HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();
            health.TakeDame();
        }
    }
}
