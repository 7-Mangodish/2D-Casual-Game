using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMakeDame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.gameObject.CompareTag("Player"))
        {
            HealthSystem healh = collision.gameObject.GetComponent<HealthSystem>();
            healh.TakeDame();
        }
    }
}
