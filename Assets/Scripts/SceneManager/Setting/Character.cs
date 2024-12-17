using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character 
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private GameObject gameCharacter;


    public Sprite getSprite()
    {
        return sprite;
    }
    public GameObject getGameCharacter()
    {
        return this.gameCharacter;
    }
}
