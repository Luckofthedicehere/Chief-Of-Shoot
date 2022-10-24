using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDatabase : MonoBehaviour
{
    [SerializeField] GameObject GeorgeWashington;
    [SerializeField] GameObject JohnAdams;
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject lockedCharacter;
    [SerializeField] GameObject nameText;
    

    private int selectedOption = 0;
    private int otherOption = 0;
    public GameObject[] presidents;
    public string[] names;
    //public GameObject nameText;

    private void Start()
    {
        //UpdateName(0);
    }

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

    public void UpdateName(int nameNum)
    {
        GameObject canvas = GameObject.Find("Canvas"); //references the canvas
        Text[] textValue = canvas.GetComponentsInChildren<Text>();//gets the text objects in the canvas
        textValue[nameNum].text = names[nameNum];//sets the text at value to the name at value (getting an index out of bounds exception)
    }

    public void NextName()
    {
        otherOption++;
        if (otherOption > names.Length - 1)
        {
            otherOption = 0;
        }
        UpdateName(otherOption);
          
    }
    public void BackName()
    {
        otherOption--;
        if(otherOption < 0)
        {
            otherOption = names.Length - 1;
        }
        UpdateName(otherOption);
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
