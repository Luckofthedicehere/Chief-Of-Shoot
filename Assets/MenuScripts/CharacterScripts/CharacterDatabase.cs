using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public Character[] character;

    public int characterCount
    {
        get
        {
            return Character.Length;
        }
    }

    public Character GetCharacter(int index)
    {
        return character(index);
    }
    
}
