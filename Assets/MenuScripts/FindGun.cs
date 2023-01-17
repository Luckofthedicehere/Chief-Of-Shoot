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

    [SerializeField] GameObject weaponHolder;

    public GameManager gamer;

    //public Transform newParent;
     

    public void Start()
    {

        selected = "testing";
        Debug.Log(selected);
        otherSelected = "otherTesting";
        Debug.Log(otherSelected);
        //GameObject auto = Resources.Load("Auto") as GameObject;

        //GameObject shotgun = Resources.Load("Shotgun") as GameObject;

        //Transform newParent = GameObject.FindWithTag("WeaponHolder").GetComponent<Transform>();


        //create 2 static strings. create an on level load in gamemanager
        //access the static strings. load from an array of prefabs to create the guns. 



    }

    public void selectGun(string name)
    {
        if (selected == "testing")
        {
            selected = name;
            Debug.Log(selected);
            //GameObject gun1 = Resources.Load(name) as GameObject; //load the selected gun
            //Transform newParent = GameObject.FindWithTag("WeaponHolder").GetComponent<Transform>();
            //gun1.transform.SetParent(newParent, false);
        }
        else
        {
            otherSelected = name;
            Debug.Log(otherSelected);
            //GameObject gun2 = Resources.Load(name) as GameObject;
            //Transform newParent = GameObject.FindWithTag("WeaponHolder").GetComponent<Transform>();
            //gun2.transform.SetParent(newParent, false);

            if(selected != "testing" && otherSelected != "otherTesting")
            {
                Debug.Log("Weapons selected, changing level");
                gamer.LoadLevel(3);
            }
            else
            {
                Debug.Log("Something went wrong. Check FindGun script");
            }
            
        }
    }

    public void disableButton(int num)
    {
        weaponButtons[num].interactable = false;       
    }

    public void findCorrectGun() //I need this to hold the value between levels
    {
        for (int i = 0; i < gunPrefabs.Length; i++)
        {
            
            if (gunPrefabs[i].name == selected) 
            {
                GameObject gun1 = gunPrefabs[i].gameObject;
                //GameObject gun1 = Resources.Load(gunPrefabs[i].name) as GameObject; //Load Gun1
                GameObject theFirstGun = Instantiate(gun1, new Vector3(1,0,0), Quaternion.identity); //instantiates gun at 1,0,0 w/no rotation

                Transform newParent = GameObject.FindWithTag("WeaponHolder").GetComponent<Transform>(); //new parent = weaponHolder
                theFirstGun.transform.SetParent(newParent, false);
                selectedNum = i;
                Debug.Log("Loaded " + gunPrefabs[i].name);
            }
            if (gunPrefabs[i].name == otherSelected)
            {

                GameObject gun2 = gunPrefabs[i].gameObject;
                //GameObject gun2 = Resources.Load(gunPrefabs[i].name) as GameObject;
                GameObject theSecondGun = Instantiate(gun2, new Vector3(1, 0, 0), Quaternion.identity);
                Transform newparent = GameObject.FindWithTag("WeaponHolder").GetComponent<Transform>();
                theSecondGun.transform.SetParent(newparent, false);
                otherSelectedNum = i; 
                Debug.Log("Also Loaded " + gunPrefabs[i].name);
            }
        }
    }



}


