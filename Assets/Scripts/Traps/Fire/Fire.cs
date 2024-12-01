using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Take Dame");
            //HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();
            //if (health != null)
            //{
            //    health.TakeDame();
            //}
        }
    }
}
