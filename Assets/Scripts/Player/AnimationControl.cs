using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator anim;
    private string curState = "Idle";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public string getCurState()
    {
        return this.curState;
    }
    public void setCurState(string newState)
    {
        this.curState = newState;
    }
    public void ChangeState(string newState)
    {
        if(curState != newState)
        {
            anim.Play(newState);
            curState = newState;
        }
    }

    public bool IsPlayingAnimation(string State)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(State) &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
            return true;
        return false;
    }
}
