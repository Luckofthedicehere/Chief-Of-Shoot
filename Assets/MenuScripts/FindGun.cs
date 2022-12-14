using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindGun : MonoBehaviour
{

    public GameObject[] gunPrefabs;

    public static string selected;

    public static string otherSelected;

    public Button[] weaponButtons;

    [SerializeField] GameObject weaponHolder;

    public GameManager gamer;

    public Transform newParent;
     

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
                gamer.LoadLevel(2);
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

   // public void findCorrectGun()
    //{
      //  for (int i = 0; i < gunPrefabs.Length; i++);
        //{
            
          //  if (gunPrefabs[i].name == selected || gunPrefabs[i].name == otherSelected) //weird error. i doesn't show up as a known int. 
            //{
              //  GameObject gun1 = Resources.Load(gunPrefabs[i]) as GameObject; //This block 
                //GameObject theFirstGun = Instantiate(gun1);
                //Transform newParent = GameObject.FindWithTag("WeaponHolder").GetComponent<Transform>();
                //theFirstGun.transform.SetParent(newParent, false); //need to delete weaponHolder script and move all the contents into this script. 
            //}
        //}
    //}

}


