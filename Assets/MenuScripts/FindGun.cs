using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGun : MonoBehaviour
{

    
    public static string selected;

    public void Start()
    {
      //  public GameObject auto = GameObject.Find("Auto");

    //public GameObject shotgun = GameObject.Find("Shotgun");

    
    }

    void selectAuto()
    {
        selected = "Auto";
    }
 
    void selectedShotgun()
    {
        selected = "Shotgun";
    }

}


