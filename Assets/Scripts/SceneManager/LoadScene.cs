using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Out Game");
    }

    public void StartButton()
    {
        SceneManager.LoadScene("SelectLevel");
    }

    public void AboutButton()
    {
        SceneManager.LoadScene("About");
    }

    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void BackToMainMenuBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }



}
