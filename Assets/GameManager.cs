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
            checkPartyMatch(PlayerPrefs.GetString("SelectedParty") );
            Debug.Log("selected party = " + PlayerPrefs.GetString("SelectedParty"));
        }
        else
        {
            Debug.Log("Level isn't playable");
        }
    }

    public void OnLevelWasLoaded()
    {
        if (IsLevelPlayable())
        {
            loadPlayer();
            checkPartyMatch(PlayerPrefs.GetString("SelectedParty"));
            Debug.Log("selected party = " + PlayerPrefs.GetString("SelectedParty") + "AJFJDJDJFd");
        }
        else
        {
            Debug.Log("Level isn't playable");
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
        if(SceneManager.GetActiveScene().buildIndex >5) //all scenes 4 and below are menu or transition
        {
            Debug.Log("scene is playable");
            return true;
        }
        Debug.Log("scene isn't playable");
        return false;
    }

    public void loadPlayer()
    {
       
            Destroy(GameObject.FindWithTag("Player"));//destroys all other player models
            GameObject president = characterPrefabs[CharacterDatabase.presidentFinalNum].gameObject;    
            Instantiate(president, new Vector3(0,5,0), Quaternion.identity); //instantiates president
            Debug.Log("loaded president " + CharacterDatabase.presidentFinalNum);
            

            Object gun1 = gunPrefabs[FindGun.selectedNum];
            GameObject gun1Ref = Instantiate(gun1) as GameObject;
            gun1Ref.transform.parent = GameObject.FindWithTag("WeaponHolder").GetComponent<Transform>();
            gun1Ref.gameObject.tag = "Gun1";

           
            Debug.Log("attached gun1");


            Object gun2 = gunPrefabs[FindGun.otherSelectedNum];
            GameObject gun2Ref = Instantiate(gun2) as GameObject;
            gun2Ref.transform.parent = GameObject.FindWithTag("WeaponHolder").GetComponent<Transform>();
            gun2Ref.gameObject.tag = "Gun2";

            Debug.Log("attached gun2");
            

            
        
    }
    public void selectParty(string party)
    {
        PlayerPrefs.SetString("SelectedParty", "blank");
        PlayerPrefs.SetString("SelectedParty", party);
        Debug.Log(PlayerPrefs.GetString("SelectedParty"));
    }

    public void checkPartyMatch(string partyVal) //not beng called at all. need to fix
    {
        
        GameObject playerObject = GameObject.Find("PlayerObject"); //somthing wrong with this
        if (playerObject.tag == partyVal)
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


  

   
