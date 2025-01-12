using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void Died()
    {
        anim.Play("Die");
    }
    public void InitParticle()
    {
        Destroy(this.gameObject);
        if (particle != null)
        {
            Instantiate(particle, this.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Can not init Particle");
        }
    }
}
