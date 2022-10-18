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

    private int selectedOption = 0;
    public GameObject[] presidents;

    private void Start()
    {
     
    }

    //public int test = 2;
   
    public GameObject GetCharacter(int characterArray) //for determining the character 
    {
        return presidents[characterArray];
    }

    public void noCharacter(int president)
    {
        presidents[president].SetActive(false);
    }

    public void UpdateCharacter(int president)
    {
        presidents[president].SetActive(true);
    }

     
    public void nextCharacter()
    {

        noCharacter(selectedOption);
        selectedOption++;
        if (selectedOption > presidents.Length-1)
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);

    }

    public void backChacarter()
    {
        noCharacter(selectedOption);
        selectedOption--;


        if (selectedOption < 0)
        {
            selectedOption = presidents.Length-1;
        }
       UpdateCharacter(selectedOption);
    }


}
