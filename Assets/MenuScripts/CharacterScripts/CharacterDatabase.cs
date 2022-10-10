using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDatabaseFirst : MonoBehaviour
{
    [SerializeField] GameObject GeorgeWashington;
    [SerializeField] GameObject JohnAdams;

    public TextMesh nameText;

    public int charactersTotal = 2;//update when adding a new character
    public int SelectedCharacter = 0;

    public int[] CharacterArray = new int[1]; //update when adding a new character

    public int GetCharacter(int characterArray)
    {
        return CharacterArray[characterArray];
    }

}
