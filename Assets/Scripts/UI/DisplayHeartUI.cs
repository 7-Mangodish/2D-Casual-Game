using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHeartUI : MonoBehaviour
{
    [SerializeField] private Image[] image = new Image[3];
    [SerializeField] private Sprite fullHeart ;
    [SerializeField] private Sprite blankHeart;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int cntHeart = PlayerPrefs.GetInt("curHeart");
        for(int i = 0; i<3; i++)
        {
            if(i < cntHeart)
                image[i].sprite = fullHeart;
            else
                image[i].sprite = blankHeart;
        }
    }
}
