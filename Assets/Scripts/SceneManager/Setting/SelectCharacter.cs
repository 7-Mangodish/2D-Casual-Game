using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private CharacterObject characterObject;
    [SerializeField] private SpriteRenderer spriteRendererCharacter;
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
        setCharacterSprite();
    }

    public void backOptionCharacter()
    {
        characterIndex--;
        if (characterIndex <0)
        {
            characterIndex = characterObject.getCharacterCount()-1;
        }
        setCharacterSprite();
    }

    private void setCharacterSprite()
    {
        spriteRendererCharacter.sprite = characterObject.getSpriteCharacter(characterIndex);
        PlayerPrefs.SetInt("characterIndex", characterIndex);
    }

    private void loadCharacterSprite()
    {
        int index = PlayerPrefs.GetInt("characterIndex");
        spriteRendererCharacter.sprite = characterObject.getSpriteCharacter(index);

    }
}
