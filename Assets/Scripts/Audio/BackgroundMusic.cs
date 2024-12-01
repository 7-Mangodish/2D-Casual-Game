using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    void Start()
    {
        AudioManager audio = FindObjectOfType<AudioManager>();
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            audio.PlayBackgroundSound("MenuBackground");
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            audio.PlayBackgroundSound("Level1Background");
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            audio.PlayBackgroundSound("Level2Background");
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            audio.PlayBackgroundSound("Level3Background");
        }
    }
}
