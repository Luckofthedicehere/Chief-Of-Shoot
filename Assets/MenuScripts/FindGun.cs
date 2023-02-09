using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindGun : MonoBehaviour
{

    public GameObject[] gunPrefabs;

    public static string selected;

    public static string otherSelected;

    public static int selectedNum = 0;

    public static int otherSelectedNum = 1;

    public Button[] weaponButtons;

    //[SerializeField] GameObject weaponHolder;

    public GameManager gamer;

    //public Transform newParent;
     

    public void Start()
    {

        selected = "testing";
        Debug.Log(selected);
        otherSelected = "otherTesting";
        Debug.Log(otherSelected);


        //create 2 static strings. create an on level load in gamemanager
        //access the static strings. load from an array of prefabs to create the guns. 

    }

    public void selectGun(string name)
    {
        if (selected == "testing")
        {
            selected = name;
            Debug.Log(selected);
       
        }
        else
        {
            otherSelected = name;
            Debug.Log(otherSelected);

            if(selected != "testing" && otherSelected != "otherTesting")
            {
                Debug.Log("Weapons selected, changing level");
                gamer.LoadLevel(4);
            }
            else
            {
                Debug.Log("Something went wrong. Check FindGun script");
            }
            
        }
    }

    public void disableButton(string tagName) //make this disable all main or side guns
    {
        for(int i = 0; i<weaponButtons.Length; i++)
        {
            if(weaponButtons[i].tag == tagName)
            {
                weaponButtons[i].interactable = false;
            }
        }
              
    }

    public void findCorrectGun() //I need this to hold the value between levels
    {
        for (int i = 0; i < gunPrefabs.Length; i++)
        {
            
            if (gunPrefabs[i].name == selected) 
            {
           
                selectedNum = i;
                Debug.Log("Loaded " + gunPrefabs[i].name);
            }
            if (gunPrefabs[i].name == otherSelected)
            {

       
                otherSelectedNum = i; 
                Debug.Log("Also Loaded " + gunPrefabs[i].name);
            }
        }
    }



}


