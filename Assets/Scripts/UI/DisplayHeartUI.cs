using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHeartUI : MonoBehaviour
{
    [SerializeField] private Image[] image = new Image[3];
    [SerializeField] private Sprite fullHeart ;
    [SerializeField] private Sprite blankHeart;

    void Update()
    {
        int cntHeart = GameManager.Instance.GetHeart();
        for(int i = 0; i<3; i++)
        {
            if(i < cntHeart)
                image[i].sprite = fullHeart;
            else
                image[i].sprite = blankHeart;
        }
    }
}
