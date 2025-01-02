using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private CharacterObject characterObject;
    [SerializeField] private Image characterImg;
    private int characterIndex = 0;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("characterIndex"))
        {
            PlayerPrefs.SetInt("characterIndex", 0);
        }
    }
    public void nextOptionCharacter()
    {
        characterIndex++;
        if(characterIndex == characterObject.getCharacterCount()) 
        {
            characterIndex = 0;
        }
        setCharacterImage();
        FindObjectOfType<AudioManager>().PlaySfx("ClickBtn 1");
    }

    public void backOptionCharacter()
    {
        characterIndex--;
        if (characterIndex <0)
        {
            characterIndex = characterObject.getCharacterCount()-1;
        }
        setCharacterImage();
        FindObjectOfType<AudioManager>().PlaySfx("ClickBtn 1");

    }

    private void setCharacterImage()
    {
        characterImg.sprite = characterObject.getSpriteCharacter(characterIndex);
        PlayerPrefs.SetInt("characterIndex", characterIndex);
    }

    private void loadCharacterSprite()
    {
        int index = PlayerPrefs.GetInt("characterIndex");
        characterImg.sprite = characterObject.getSpriteCharacter(index);

    }
}
