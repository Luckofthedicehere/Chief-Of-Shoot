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
    [SerializeField] TMPro.TextMeshProUGUI nameText;
    [SerializeField] TMPro.TextMeshProUGUI boxDisplayText;
    [SerializeField] GameObject playButton;
    public GameObject[]  BlurbText;


    GameManager gmanager;
    private int selectedOption = 0;
    private int otherOption = 0;
    public GameObject[] presidents;
    public string[] names;
    //public GameObject nameText;
    public GameObject locked;
    public static int presidentFinalNum = 0;
    

    private void Start()
    {
        UpdateName(0);
        
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
        if (selectedOption > PlayerPrefs.GetInt("levelReached"))
        {
            lockedCharacter.SetActive(true);
            playButton.SetActive(false);
            
        }
        else
        {
            lockedCharacter.SetActive(false);
            presidents[president].SetActive(true);
            playButton.SetActive(true);
        }


       
    }

    public void UpdateName(int nameNum)
    {
        Debug.Log(selectedOption);
        nameText.text = names[nameNum]; //error that doesn't matter here. It is referenced before it shows up, but still works. 
        boxDisplayText.text = selectedOption + 1 + "";

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
            if (selectedOption > presidents.Length - 1)
            {
                selectedOption = 0;
            }
            UpdateCharacter(selectedOption);
       
        //checkUnlockCharacter();
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
       //checkUnlockCharacter();
    }

    public void confirmCharacter()
    {
        presidentFinalNum = selectedOption; //set the static int to selectedOption so it can carry over between levels
        Debug.Log("number " + presidentFinalNum + " president loaded");
    }

    public void checkUnlockCharacter() //basically not needed. 
    {
        
        if (gmanager.LevelsBeaten < selectedOption)
        {
            noCharacter(selectedOption);
            locked.SetActive(true);
           
        }
        else if(locked==true)
        {
            locked.SetActive(false);
        }
    }

}
