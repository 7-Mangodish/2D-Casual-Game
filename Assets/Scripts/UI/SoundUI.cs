using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUI : MonoBehaviour
{
    private AudioManager audio;
    private void Awake()
    {
        audio = FindObjectOfType<AudioManager>();
    }

    public void HoverBtn()
    {
        audio.PlaySfx("HoverBtn");
    }
    public void ClickBtn()
    {
        audio.PlaySfx("ClickBtn 1");
    }
}
