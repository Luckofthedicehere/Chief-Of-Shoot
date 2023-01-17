using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    

    private void Start()
    {
        PlayerPrefs.SetInt("levelsReached", 1);
        Debug.Log("Level reached = 1");
        DontDestroyOnLoad(this);
        //LoadLevel(0);
        NewGame();
        LoadMainMenu();
        if (IsLevelPlayable())
        {
            loadPlayer();
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
        if(SceneManager.GetActiveScene().buildIndex >4) //all scenes 4 and below are menu or transition
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
            Destroy(GameObject.FindWithTag("Player"));//destroys player
            GameObject president = characterPrefabs[CharacterDatabase.presidentFinalNum].gameObject;    
            Instantiate(president, new Vector3(0,5,0), Quaternion.identity); //instantiates president
            Debug.Log("loaded president " + CharacterDatabase.presidentFinalNum);

            //GameObject holder = GameObject.FindWithTag("WeaponHolder");
            

            Object gun1 = gunPrefabs[FindGun.selectedNum];
            GameObject gun1Ref = Instantiate(gun1) as GameObject;
            gun1Ref.transform.parent = GameObject.FindWithTag("WeaponHolder").GetComponent<Transform>();
            gun1Ref.gameObject.tag = "Gun1";

            //Instantiate into player
            //Instantiate(gun1, new Vector3(0, 5, 0), Quaternion.identity);
            //Transform newParent = GameObject.FindWithTag("WeaponHolder").GetComponent<Transform>();
            //gun1.transform.SetParent(newParent,false);
            Debug.Log("attached gun1");


            Object gun2 = gunPrefabs[FindGun.otherSelectedNum];
            GameObject gun2Ref = Instantiate(gun2) as GameObject;
            gun2Ref.transform.parent = GameObject.FindWithTag("WeaponHolder").GetComponent<Transform>();
            gun2Ref.gameObject.tag = "Gun2";

            //Instantiate(gun2, new Vector3(0, 5, 0), Quaternion.identity);
            //gun2.transform.SetParent(newParent, false);
            Debug.Log("attached gun2");
            
        }
    }
    //public void destroyAllChildren() //not complete, probably not needed
    //{
        //var allChildren = GameObject.FindWithTag("WeaponHolder").GetComponentsInChildren(Transform);

      //  foreach ( in GameObject.FindWithTag("WeaponHolder").transform) ; //for every child in weaponholder
   // }

    public void winLevel()
    {
        Debug.Log("Level Beaten. Great Job Mr. President");
        PlayerPrefs.SetInt("levelReached", LevelToUnlock); //takes the saved player prefs int and changees it
        Debug.Log(PlayerPrefs.GetInt("levelReached"));
    }

    //public void OnLevelWasLoaded()
    //{
        
     //   {
       //     characterPrefabs[CharacterDatabase.presidentFinalNum].SetActive(true);
        //}
    //}


    //public void OnLevelLoaded()
    //{
    //  gunFinder.findCorrectGun();
    //Debug.Log("LevelWasLoaded");
    //}

}


  

   
