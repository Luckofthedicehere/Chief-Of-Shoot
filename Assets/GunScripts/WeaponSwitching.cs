using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{

    public int selectedWeapon = 0; 
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
            SelectWeapon();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 1;
            SelectWeapon();
        }

    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);

            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
