using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPos;
    private Animator anim;

    private float coolDown;
    private float timeDuration;
    void Start()
    {
        anim = GetComponent<Animator>();
        timeDuration = 0;
        coolDown = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timeDuration += Time.deltaTime;
        if (timeDuration >= coolDown)
        {
            timeDuration = 0;
            anim.Play("Attack");
            Invoke("setIdle", 0.5f);
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
    private void setIdle()
    {
        anim.Play("Idle");
    }
}
