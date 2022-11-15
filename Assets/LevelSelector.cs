using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public GameManager gameManager;

    public Button[] levelButtons;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt ("levelReached",1); //saves player progress

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i+1 > levelReached)
            {
                levelButtons[i].interactable = false;
                
            }
        }
    }




    //public void Select(string levelName) hopefully make this load levels through names. 
    //{

    //}
    //don't actually need this

}
