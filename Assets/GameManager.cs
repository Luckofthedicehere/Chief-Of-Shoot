using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int LevelsBeaten;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;
  
    private void Start()
    {
        DontDestroyOnLoad(this);
        LoadLevel(0);
        NewGame();
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
    private void LoadLevel(int index)
    {

    }
}


  

   
