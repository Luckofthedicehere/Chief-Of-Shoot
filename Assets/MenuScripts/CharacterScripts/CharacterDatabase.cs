using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterDatabase : MonoBehaviour
{
    [SerializeField] GameObject GeorgeWashington;
    [SerializeField] GameObject JohnAdams;
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject lockedCharacter;

    
    public TextMesh nameText;
    GameObject[] presidents;//look up"how to make an array of gameobjects unity, for the tutorial"
    public int test = 2;
    public int charactersTotal = 2;//update when adding a new character
    public int SelectedCharacter = 0;

    public int[] CharacterArray = new int[1]; //update when adding a new character

    public int GetCharacter(int characterArray) //for determining the character 
    {
        return CharacterArray[characterArray];
    }

    public void UpdateCharacter(int president)
    {
        presidents[president].SetActive(true);
    }

}
