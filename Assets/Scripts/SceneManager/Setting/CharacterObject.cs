using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character")]
public class CharacterObject : ScriptableObject
{
    public Character[] character;
    public int getCharacterCount()
    {
        return character.Length;
    }

    public Sprite getSpriteCharacter(int index)
    {
        return this.character[index].getSprite();
    }
    public GameObject getCharacter(int index)
    {
        return this.character[index].getGameCharacter();
    }
}
