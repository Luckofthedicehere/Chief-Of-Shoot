using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{

    public CharacterDatabase CharacterDB;

    private int selectedOption = 0;

    public void nextCharacter()
    {
        selectedOption++; 
        
    }

    public void backChacarter()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = CharacterDB.characterCount;
        }
    }

    private void updateCharacter(int selectedOption)
    {

    }
}