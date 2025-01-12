using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUI : MonoBehaviour
{

    public void HoverBtn()
    {
        AudioManager.Instance.PlaySfx("HoverBtn");
    }
    public void ClickBtn()
    {
        AudioManager.Instance.PlaySfx("ClickBtn");
    }

    public void ClickBtn1()
    {
        AudioManager.Instance.PlaySfx("ClickBtn 1");

    }
}
