using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowSpike : MonoBehaviour
{
    [SerializeField] private GameObject makeDameArea;

    private Animator anim;
    string  curState, newState;
    void Start()
    {
        anim = GetComponent<Animator>();
        curState = "Idle";
        newState = "Idle";
        StartCoroutine(curState);
    }

    void Update()
    {
        if (curState == newState)
            return;
        else
        {
            curState = newState;
            StartCoroutine(curState); 
        }
    }
    private IEnumerator Idle()
    {
        anim.Play("Idle");
        makeDameArea.SetActive(false);
        yield return new WaitForSeconds(2f);
        newState = "MakeDame";
    }
    
    private IEnumerator MakeDame()
    {
        anim.Play("MakeDame");
        makeDameArea.SetActive(true);
        yield return new WaitForSeconds(4f);
        newState = "Idle";
    }
}
