using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Gun;
    public bool aiming;
    public Canvas Crosshair;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            aiming = true;
            Gun.GetComponent<Animator>().Play("AimDownSight");
            Crosshair.gameObject.SetActive(true);

        }

        if (Input.GetMouseButtonUp(1))
        {
            Gun.GetComponent<Animator>().Play("New State");
            Crosshair.gameObject.SetActive(false);

        }
    }
}
