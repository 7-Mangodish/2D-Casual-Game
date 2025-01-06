using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    [SerializeField] private Button[] levelBtn;
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("LevelAt", 0);

        for(int i=0; i< levelBtn.Length; i++)
        {
            if(i <= levelAt)
                levelBtn[i].interactable = true;
            else
                levelBtn[i].interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int number)
    {
        SceneManager.LoadScene("Level" + number.ToString());
    }
}
