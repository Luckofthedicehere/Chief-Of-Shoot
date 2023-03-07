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
    [SerializeField] TMPro.TextMeshProUGUI BlurbText;
    [SerializeField] TMPro.TextMeshProUGUI walkSpeed;
    [SerializeField] TMPro.TextMeshProUGUI sprintSpeed;
    [SerializeField] TMPro.TextMeshProUGUI dashSpeed;
    [SerializeField] TMPro.TextMeshProUGUI jumpHeight; 
   


    GameManager gmanager;

    private int selectedOption = 0;
    private int otherOption = 0;
    public GameObject[] presidents;
    public string[] names;
    public string[] blurbs;
    //public GameObject nameText;
    public GameObject locked;
    public static int presidentFinalNum = 0;
    

    private void Start()
    {
        UpdateName(0);
        UpdateHistory(0);
        
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

    public void UpdateHistory(int blurbNum)
    {
        Debug.Log(selectedOption + " blurb");
        BlurbText.text = blurbs[blurbNum]; //error that doesn't matter here. It is referenced before it shows up, but still works.
    }

    public int getWalkSpeed()
    {
        PlayerMovment1 pm1 = GameObject.Find(presidents[selectedOption].name).GetComponent<PlayerMovment1>(); //something is wrong, pm1 is not showing up as a valied object
        Debug.Log(presidents[selectedOption].name +" a a a a a a ");
        int newWalk = (int)pm1.walkSpeed;   
        return newWalk; 
    }

    public float getSprintSpeed()
    {
        PlayerMovment1 pm1 = presidents[selectedOption].GetComponent<PlayerMovment1>();
        return pm1.sprintSpeed;
    }

    public float getDashSpeed()
    {
        PlayerMovment1 pm1 = presidents[selectedOption].GetComponent<PlayerMovment1>();
        return pm1.dashSpeed;
    }

    public float getJumpHeight()
    {
        PlayerMovment1 pm1 = presidents[selectedOption].GetComponent<PlayerMovment1>();
        return pm1.jumpForce;
    }

    public void UpdateMenuStats()
    {
        walkSpeed.text = getWalkSpeed().ToString();
        sprintSpeed.text = getSprintSpeed().ToString();
        dashSpeed.text = getSprintSpeed().ToString();
        jumpHeight.text = getJumpHeight().ToString();
    }

    public void NextName()
    {
        otherOption++;
        if (otherOption > names.Length - 1)
        {
            otherOption = 0;
        }
        UpdateName(otherOption);
        UpdateHistory(otherOption);
        UpdateMenuStats();
          
    }
    public void BackName()
    {
        otherOption--;
        if(otherOption < 0)
        {
            otherOption = names.Length - 1;
        }
        UpdateName(otherOption);
        UpdateHistory(otherOption);
        UpdateMenuStats();

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
        UpdateHistory(selectedOption);
        UpdateMenuStats();
       
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
        UpdateHistory(selectedOption);
        UpdateMenuStats();
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
