using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{
    private TextMeshProUGUI textScore;

    void Start()
    { 
        textScore = GetComponent<TextMeshProUGUI>();
        if(textScore == null)
        {
            Debug.Log("Can't find textScore");
        }
    }


    void Update()
    {
        int scores = GameManager.Instance.GetCurrentScore();
        if (textScore != null)
        {
            textScore.text = "Score: " + scores;
        }
    }

}
