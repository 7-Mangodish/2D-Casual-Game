using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player")) 
        {
            anim.SetTrigger("Touching");

            int levelAt = PlayerPrefs.GetInt("LevelAt");
            PlayerPrefs.SetInt("LevelAt", levelAt + 1);
        }
    }
    void afterTouching()
    {
        anim.SetTrigger("AfterTouching");
        UIManager.isFinish = true;
        AudioManager.Instance.PlaySfx("FinishLevel");
    }

}
