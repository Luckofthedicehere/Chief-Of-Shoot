using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Gun;
    public bool aiming;
    public Canvas Crosshair;
    public GameObject CrosshairParent;
    void Start()
    {
        Gun = this.gameObject;
        aiming = false;
        Crosshair = GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Canvas>();
        
        /*
        if (Gun.tag == "Gun2")
        {
            Crosshair.gameObject.SetActive(false);
        }
        */

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            aiming = true;
            Debug.Log(aiming);
            Gun.GetComponent<Animator>().Play("AimDownSight");
            Crosshair.gameObject.SetActive(true);

        }

        if (Input.GetMouseButtonUp(1))
        {
            aiming = false;
            Debug.Log(aiming);
            Gun.GetComponent<Animator>().Play("New State");
            Crosshair.gameObject.SetActive(false);

        }
    }

    public void DisableCrosshair()
    {
        Crosshair.gameObject.SetActive(false);
    }
}
