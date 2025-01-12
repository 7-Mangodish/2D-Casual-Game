using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject makeDameArea;
    [SerializeField] private float timeFire;

    private float timeDuration;
    private Animator anim;
    private bool isOff;
    void Start()
    {
        anim = GetComponent<Animator>();
        isOff = true;
        timeDuration = 0;
    }

    private void Update()
    {
        if (!isOff)
        {
            timeDuration += Time.deltaTime;
            if(timeDuration > timeFire)
            {
                timeDuration = 0;
                TurnOff();
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOff)
        {
            anim.Play("Hit");
        }
    }

    public void TurnOn()
    {
        makeDameArea.SetActive(true); 
        isOff = false;
    }

    private void TurnOff()
    {
        anim.Play("Off");
        isOff = true;
        makeDameArea.SetActive(false);
    }
}
