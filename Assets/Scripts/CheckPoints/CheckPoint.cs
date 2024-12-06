using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

}
