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
        //if (IsLevelPlayable())
        //{
          //  loadPlayer();
            //checkPartyMatch();
            //Debug.Log("selected party = " + PlayerPrefs.GetString("SelectedParty"));
        //}
        //else
        //{
         //   Debug.Log("Level isn't playable");
        //}
    }

    public void Awake()
    {
        if (IsLevelPlayable())
        {
            Debug.Log("Scene is really playable");
            Debug.Log("selected party = " + PlayerPrefs.GetString("SelectedParty") + "AJFJDJDJFd");
            loadPlayer();
            if( checkPartyMatch())
            {
                
                Invoke ("DoubleStats", 0.5f);
            }
            
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
            Instantiate(president, new Vector3(5,5,5), Quaternion.identity); 
            Debug.Log("loaded president " + CharacterDatabase.presidentFinalNum);
            


            Object gun1 = gunPrefabs[FindGun.selectedNum];
            if (FindGun.selectedNum == 0)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 1)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 2)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 3)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 4)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 5)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 6)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 7)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 8)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 9)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 10)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 11)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 12)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 13)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 14)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 15)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 16)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 17)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.selectedNum == 18)
            {
                position = new Vector3(0, 0, 0);
            }
           
            GameObject gun1Ref = Instantiate(gun1, position, Quaternion.identity) as GameObject;
            gun1Ref.transform.parent = GameObject.FindWithTag("WeaponHolder").GetComponent<Transform>();
            gun1Ref.gameObject.tag = "Gun1";

           
            Debug.Log("attached gun1");


            Object gun2 = gunPrefabs[FindGun.otherSelectedNum];
            if (FindGun.selectedNum == 0)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 1)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 2)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 3)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 4)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 5)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 6)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 7)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 8)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 9)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 10)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 11)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 12)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 13)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 14)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 15)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 16)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 17)
            {
                position = new Vector3(0, 0, 0);
            }
            else if (FindGun.otherSelectedNum == 18)
            {
                position = new Vector3(0, 0, 0);
            }

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

    public bool checkPartyMatch() //not beng called at all. need to fix
    {
        GameObject playerObject = GameObject.Find("PlayerObject"); //somthing wrong with this
        Debug.Log(playerObject.tag + " is the tag of player object");
        if (PlayerPrefs.GetString("SelectedParty") == playerObject.tag )
        {
            Debug.Log("match is true");
            return true;
        }
        else {
            Debug.Log(" match is false");
            return false;
        }
          
        
    }

    
    public void DoubleStats()   
    {
         PlayerMovment1 pm1 = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment1>();
       

        pm1.dashSpeed = pm1.dashSpeed * 2;
        Debug.Log("Doubling dashSpeed");
        pm1.sprintSpeed = pm1.sprintSpeed * 2;
        Debug.Log("Doubling sprint");
        pm1.jumpForce = pm1.jumpForce * 2;
        Debug.Log("Doubling JumpForce");
        pm1.walkSpeed = pm1.walkSpeed * 2;
        Debug.Log("Doubling WalkSpeed");
            
            
            //tar.health = tar.health * 2;
            //Debug.Log("Doubling health");
      

           
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


  

   
