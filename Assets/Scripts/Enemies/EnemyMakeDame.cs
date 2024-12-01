using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMakeDame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

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
