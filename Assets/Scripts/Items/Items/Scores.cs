using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI textScore;

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "Level0" && !PlayerPrefs.HasKey("score") ) 
        {
            Debug.Log("Level0");
            PlayerPrefs.SetInt("score", 0);

        }
    }
    void Start()
    {
        // Return the first active Object 
        textScore = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int scores = PlayerPrefs.GetInt("score");
        if (textScore != null)
        {
            textScore.text = "Score: " + scores;
        }
    }

}
