using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector3 direct;
    [SerializeField] private float distance;
    [SerializeField] private float force;
    [SerializeField] private LayerMask layer;
    [SerializeField] private GameObject particle;
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direct * force * Time.deltaTime);
        RaycastHit2D hitInfor = Physics2D.Raycast(transform.position, direct, distance, layer);
        if (hitInfor.collider != null )
        {

            if (hitInfor.collider.gameObject.CompareTag("Player") ) {
                if (hitInfor.collider.GetComponent<HealthSystem>().isTakeDame == false)
                {
                    HealthSystem player = hitInfor.collider.gameObject.GetComponent<HealthSystem>();
                    player.TakeDame();
                }

            }

            if (hitInfor.collider.gameObject.CompareTag("Ground"))
            {
                Instantiate(particle, this.transform.position, Quaternion.identity);
            }
            desTroyBullet();
        }
        Invoke(nameof(desTroyBullet), 3f);
    }
    
    void desTroyBullet()
    {
        Destroy(gameObject);
    }
}
