using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }

    private int currentScore;
    private int star;
    private int heart;

    public int GetCurrentScore()
    {
        return currentScore;
    }
    public void SetCurrentScore(int score)
    {
        currentScore = score;
    }
    public void UpdateCurrentScore()
    {
        currentScore += 100;
    }
    public int GetStar()
    {
        return star;
    }

    public void SetStarLevel( int cntStar)
    {
        star = cntStar;
    }

    public void UpdateStar()
    {
        star++;
    }

    public int GetHeart()
    {
        return heart;
    }
    public void SetHeart(int newHeart)
    {
        this.heart = newHeart;
        if (heart > 3)
            this.heart = 3;
    }
    public void SaveScoreAndStar()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string level = sceneName.Substring(sceneName.Length - 1);
        string starKey = "StarAtLevel" + level,
               scoreKey = "ScoreAtLevel" + level;

        PlayerPrefs.SetInt(starKey, this.star);
        PlayerPrefs.SetInt(scoreKey, this.currentScore);
    }
    private void Awake()
    {
        currentScore = 0;
        heart = 2;

        if(instance == null)
            instance = this;
        else
        {
            Debug.Log("The second GameManger is innitiated");
            Destroy(gameObject);
        }
    }
    
    
}
