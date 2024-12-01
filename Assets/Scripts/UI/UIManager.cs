using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static bool isPause;
    public static bool isFinish;
    public static bool isDied;
    public GameObject pauseMenu;
    public GameObject finishMenu;
    public GameObject dieMenu;

    public Animator effect;
    private void Awake()
    {
        isPause = false;
        isDied = false;
        isFinish = false;
        //Debug.Log(isPause);
        //Debug.Log(isDied);
        //Debug.Log(isFinish);
    }
    void Start()
    {
        //if (SceneManager.GetActiveScene().buildIndex == 0)
        //{
        //    audioManager.PlayBackgroundSound("MenuBackground");
        //}
        //else if (SceneManager.GetActiveScene().buildIndex == 1)
        //{
        //    audioManager.PlayBackgroundSound("Level1Background");
        //}
        //else if (SceneManager.GetActiveScene().buildIndex == 2)
        //{
        //    audioManager.PlayBackgroundSound("Level2Background");
        //}
        //else if (SceneManager.GetActiveScene().buildIndex == 3)
        //{
        //    audioManager.PlayBackgroundSound("Level3Background");
        //}
        //Debug.Log(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        SetUI();
    }

    private void SetUI()
    {
        if (isDied)
        {
            LoadDieMenu();
        }
        else
        {
            if (isFinish)
                LoadFinishMenu();
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (isPause)
                    {
                        Resume();
                    }
                    else
                        Pause();
                }
            }

        }
    }
    public void LoadFinishMenu()
    {
        finishMenu.SetActive(true);
        isFinish = false;
    }

    public void LoadDieMenu()
    {
        dieMenu.SetActive(true);
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPause = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPause = true;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Replay(int num)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level" + num.ToString());
    }

    public void LoadNextLevel(int num)
    {
        SceneManager.LoadScene("Level" + num.ToString());
    }

}
