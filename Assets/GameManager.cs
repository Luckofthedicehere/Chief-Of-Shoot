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
    private void Start()
    {
        DontDestroyOnLoad(this);
        //LoadLevel(0);
        NewGame();
        LoadMainMenu();
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
    private void LevelWin()
    {
        LevelsBeaten++;
        LoadLevel(0);
        LoadMainMenu();
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

    public void retry() //video 28. 
    {
        //getActvieScene() something like that. 
    }


    public void winLevel()
    {
        Debug.Log("Level Beaten. Great Job Mr. President");
        PlayerPrefs.SetInt("levelReached", LevelToUnlock); //need to make an array and change this. Also need to make a similar script for presidents. (takes the saved player prefs int and changees it)
    }



}


  

   
