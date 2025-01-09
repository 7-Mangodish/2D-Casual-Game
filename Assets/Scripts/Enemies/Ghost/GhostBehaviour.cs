using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GhostBehaviour : MonoBehaviour
{
    [SerializeField] private List<Transform> listPoint;
    [SerializeField] private float timeCoolDown;

    private float timeDuration;
    private float randPosX;
    private float minPosX, maxPosX;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        minPosX = Math.Min(listPoint[0].position.x, listPoint[1].position.x);
        maxPosX = Math.Max(listPoint[0].position.x, listPoint[1].position.x);
        timeDuration = 0;
    }

    void Update()
    {
        timeDuration += Time.deltaTime;
        if (timeDuration > timeCoolDown)
        {
            anim.Play("Desappear");
            timeDuration = 0;

        }
    }

    private void Spawn()
    {
        randPosX = Random.Range(minPosX, maxPosX);
        Debug.Log(randPosX);
        this.transform.position = new Vector3(randPosX, this.transform.position.y);
    }
}
