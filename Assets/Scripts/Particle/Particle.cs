using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private ParticleSystem parSystem;
    private float lifeTime;
    void Start()
    {
        parSystem = GetComponent<ParticleSystem>();
        if (parSystem == null)
        {
            lifeTime = parSystem.startLifetime;
            Debug.Log(lifeTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Invoke(nameof(DestroyBulletSpieces), lifeTime);
    }
    private void DestroyBulletSpieces()
    {
        Destroy(this.gameObject);
    }
}
