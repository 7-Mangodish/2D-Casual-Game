using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayStar : MonoBehaviour
{
    [SerializeField] private Sprite emptyStar;
    [SerializeField] private Sprite fullStar;
    [SerializeField] private Image[] listStar;
    [SerializeField] private int level;
    private void Awake()
    {
        int cntStar;
        if(SceneManager.GetActiveScene().name == "SelectLevel")
        {
            if (!PlayerPrefs.HasKey("StarAtLevel" + level))
            {
                PlayerPrefs.SetInt("StarAtLevel" + level, 0);
            }
            cntStar = PlayerPrefs.GetInt("StarAtLevel" + level);

        }
        else
        {
            cntStar = GameManager.Instance.GetStar();
        }

        for (int i = 0; i < listStar.Length; i++)
        {
            listStar[i].sprite = (i < cntStar ? fullStar : emptyStar);
        }
    }

}
