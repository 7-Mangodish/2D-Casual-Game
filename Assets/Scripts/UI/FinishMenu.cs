using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    public static bool isFinish = false;
    public static bool isDied = false;
    public GameObject finishMenu;
    public GameObject dieMenu;
    void Start()
    {
}

    // Update is called once per frame
    void Update()
    {
        if (isFinish && !isDied)
            LoadFinishMenu();
        if(isDied)
            LoadDieMenu();
    }

    public void LoadFinishMenu()
    {
        finishMenu.SetActive(true);
        isFinish = false;
    }

    public void LoadDieMenu()
    {
        dieMenu.SetActive(true);
        isDied = false;
    }
    public void Replay(int num)
    {
        SceneManager.LoadScene("Level" + num.ToString());
        isFinish = false;
        isDied = false;
    }

    public void LoadNextLevel(int num)
    {
        SceneManager.LoadScene("Level" + num.ToString());
        isFinish = false;
        isDied = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        isFinish = false;
        isDied = false;
    }
}
