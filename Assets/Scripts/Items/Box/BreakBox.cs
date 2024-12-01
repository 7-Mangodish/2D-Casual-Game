using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBox : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layer;
    [SerializeField] private GameObject parent;
    private float force;

    void Start()
    {
        force = 1300f;
        Physics2D.IgnoreLayerCollision(3, 9, true);
    }

    void Update()
    {
        Break();
    }

    private void Break()
    {
        Collider2D[] items = Physics2D.OverlapCircleAll(transform.position, radius, layer);
        foreach (Collider2D item in items)
        {
            Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
            //GameObject itemObject = item.gameObject;
            if (rb != null)
            {
                //Debug.Log(item.gameObject.name);
                Vector2 directForce = item.transform.position - this.transform.position;
                rb.AddForce(directForce.normalized * force, ForceMode2D.Impulse);
            }
        }
        this.gameObject.SetActive(false);

        Invoke("Disapper", 2);
    }


    private void Disapper()
    {
        if (parent != null)
        {
            Destroy(parent);
        }
        else
            return;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
