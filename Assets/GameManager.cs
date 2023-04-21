using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting; 

public class GameManager : MonoBehaviour
{

    public int LevelsBeaten;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;
    //public Button[] levelButtons;
    public int LevelToUnlock = 2;
    //public GameObject player;
    public GameObject[] characterPrefabs; 
    public GameObject[] gunPrefabs;
    
    //public FindGun gunFinder; 
    public PlayerMovment1 pm1 = new PlayerMovment1();
    public Target tar = new Target();
    public Vector3 position;
    public Vector3 otherPosition;


    private void Start()
    {

        PlayerPrefs.SetInt("GunsUnlocked", 1);
        Debug.Log("GunsUnlocked =1");

        PlayerPrefs.SetInt("levelsReached", 1);
        Debug.Log("Level reached = 1");
        DontDestroyOnLoad(this);
        //LoadLevel(0);
        NewGame();
        LoadMainMenu();
        if (IsLevelPlayable())
        {
            loadPlayer();
            checkPartyMatch(PlayerPrefs.GetString("SelectedParty"));
        }
    }

    public void backToStart()
    {
        SceneManager.LoadScene(0);
        LoadMainMenu();
    }

    private void NewGame()
    {
        LevelsBeaten = 0;
        //load level and character
    }
  
    public void LoadOptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void LoadMainMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);   
    }
    //public void altLoadLevel(string levelName) want to load levels through their names, not values, so I can change the values without needing to change everything (maybe)
   
    public void QuitGame()
    {
        Application.Quit();
    }

    public bool IsLevelPlayable()
    {
        if(SceneManager.GetActiveScene().buildIndex >6) //all scenes 6 and below are menu or transition
        {
            Debug.Log("scene is playable");
            return true;
        }
        Debug.Log("scene isn't playable");
        return false;
    }

    public void loadPlayer()
    {
        if (IsLevelPlayable())
        {
            Destroy(GameObject.FindWithTag("Player"));//destroys all other player models
            GameObject president = characterPrefabs[CharacterDatabase.presidentFinalNum].gameObject;    
            Instantiate(president, new Vector3(0,5,0), Quaternion.identity); //instantiates president
            Debug.Log("loaded president " + CharacterDatabase.presidentFinalNum);
            

            Object gun1 = gunPrefabs[FindGun.selectedNum];
            Debug.Log("THIS IS THE GUN THAT WAS SELECTED: " + gun1);
            if (FindGun.selectedNum == 0)
            {
                //owen gun
                position = new Vector3(0.892f, 0f, 1.746f);
                Debug.Log("Owen Gun Coord " + position);
            }
            else if (FindGun.selectedNum == 1)
            {
                //lefaux
                position = new Vector3(0.729f, 0f, 0.971f);
            }
            else if (FindGun.selectedNum == 2)
            {
                //m1911
                position = new Vector3(0.88f, 0.24f, 1.27f);
            }
            else if (FindGun.selectedNum == 3)
            {
                //glock
                position = new Vector3(0.728f, -0.003f, 0.969f);
            }
            else if (FindGun.selectedNum == 4)
            {
                //flintlock
                position = new Vector3(0.737f, 0f, 0.877f);
            }
            else if (FindGun.selectedNum == 5)
            {
                //carcano
                position = new Vector3(1.36f, 0f, 0.97f);
            }
            else if (FindGun.selectedNum == 6)
            {
                //Henry Rifle
                position = new Vector3(1.03f, 0f, 1.5f);
            }
            else if (FindGun.selectedNum == 7)
            {
                //famas
                position = new Vector3(0.873f, 0.013f, 1.7f);
            }
            else if (FindGun.selectedNum == 8)
            {
                //deringer
                position = new Vector3(0.582f, 0.013f, 1.261f);
            }
            else if (FindGun.selectedNum == 9)
            {
                //desert eagle
                position = new Vector3(1.034f, -0.366f, 1.448f);
            }
            else if (FindGun.selectedNum == 10)
            {
                //colt revolving navy pistol
                position = new Vector3(0.965f, -0.1f, 1.612f);
            }
            else if (FindGun.selectedNum == 11)
            {
                //ak
                position = new Vector3(1.03f, -0.26f, 1.14f);
            }
           
           
            GameObject gun1Ref = Instantiate(gun1, position, Quaternion.identity) as GameObject;
            gun1Ref.transform.parent = GameObject.FindWithTag("WeaponHolder").GetComponent<Transform>();
            gun1Ref.gameObject.tag = "Gun1";

           
            Debug.Log("attached gun1");


            Object gun2 = gunPrefabs[FindGun.otherSelectedNum];
            Debug.Log("THIS IS THE GUN THAT WAS SELECTED: " + gun2);
            //*

            //5 must be added to the y coordnate value of all secondary guns b/c the player spawns at coords (0,5,0)
            //I have no clue why its necessary only for secondary guns and not primary
            if (FindGun.otherSelectedNum == 0)
            {
                //owen gun
                otherPosition = new Vector3(0.892f, 0f, 1.746f);
            }
            else if (FindGun.otherSelectedNum == 1)
            {
                //lefaux
                otherPosition = new Vector3(0.729f, 0f, 0.971f);
            }
            else if (FindGun.otherSelectedNum == 2)
            {
                //m1911
                otherPosition = new Vector3(0.88f, 0.24f, 1.27f);
            }
            else if (FindGun.otherSelectedNum == 3)
            {
                //glock
                otherPosition = new Vector3(0.728f, -0.003f, 0.969f);
            }
            else if (FindGun.otherSelectedNum == 4)
            {
                //flintlock
                otherPosition = new Vector3(0.737f, 0f, 0.877f);
            }
            else if (FindGun.otherSelectedNum == 5)
            {
                //carcano
                otherPosition = new Vector3(1.36f, 0f, 0.97f);
            }
            else if (FindGun.otherSelectedNum == 6)
            {
                //Henry Rifle
                otherPosition = new Vector3(1.03f, 0f, 1.5f);
            }
            else if (FindGun.otherSelectedNum == 7)
            {
                //famas
                otherPosition = new Vector3(0.873f, 0.013f, 1.7f);
            }
            else if (FindGun.otherSelectedNum == 8)
            {
                //deringer
                otherPosition = new Vector3(0.582f, 0.013f, 1.261f);
                
            }
            else if (FindGun.otherSelectedNum == 9)
            {
                //desert eagle
                otherPosition = new Vector3(1.034f, -0.366f, 1.448f);
            }
            else if (FindGun.otherSelectedNum == 10)
            {
                //colt revolving navy pistol
                otherPosition = new Vector3(0.965f, -0.1f, 1.612f);
            }
            else if (FindGun.otherSelectedNum == 11)
            {
                //ak
                otherPosition = new Vector3(1.03f, -0.26f, 1.14f);
            }
            //*/

            GameObject gun2Ref = Instantiate(gun2, otherPosition, Quaternion.identity) as GameObject;
            gun2Ref.transform.parent = GameObject.FindWithTag("WeaponHolder").GetComponent<Transform>();
            gun2Ref.gameObject.tag = "Gun2";



            Debug.Log("2nd Gun Coord " + otherPosition);
            Debug.Log("attached gun2");
            

            
        }
    }
    public void selectParty(string party)
    {
        PlayerPrefs.SetString("SelectedParty", "blank");
        PlayerPrefs.SetString("SelectedParty", party);
        Debug.Log(PlayerPrefs.GetString("SelectedParty"));
    }

    public void checkPartyMatch(string partyVal)
    {
         
        GameObject playerObject = GameObject.Find("PlayerObject");
        if (playerObject.CompareTag (partyVal))
        {
            pm1.walkSpeed = pm1.walkSpeed * 2;
            Debug.Log("Doubling speed");
            pm1.sprintSpeed = pm1.sprintSpeed * 2;
            Debug.Log("Doubling sprint");
            tar.health = tar.health * 2;
            Debug.Log("Doubling health");
        }
        else {
            Debug.Log("tags don't match");         
        }

           
        }   
            //if (characterPrefabs[playerVal])


             //GameObject.FindWithTag(partyVal).GetComponentInParent() 

            //tag a child of each president their party
            //get the parent of the gameobject with the tag
            //check if party = playerpref
            //find gameobject with tag(playerpref).getparent. getcompenent (playermovement 1) or public player movement 1. 
  
    


    public void winLevel() //need to enable (call) this to unlock levels
    {

        for (int i = 0; i < LevelToUnlock; i++)
        {
            if (i % 5 == 0 && LevelToUnlock > PlayerPrefs.GetInt("levelReached")) //if the next level is divisible by 5 and a larger number than the levels reached.
            {
                PlayerPrefs.SetInt("GunsUnlocked", PlayerPrefs.GetInt("GunsUnlocked") + 1);
                Debug.Log(PlayerPrefs.GetInt("GunsUnlocked"));
            }
        }

        Debug.Log("Level Beaten. Great Job Mr. President");
        PlayerPrefs.SetInt("levelReached", LevelToUnlock); //takes the saved player prefs int and changees it
        Debug.Log(PlayerPrefs.GetInt("levelReached"));

       
    }

}


  

   
