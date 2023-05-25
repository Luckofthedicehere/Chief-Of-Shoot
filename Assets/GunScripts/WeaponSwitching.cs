using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public Aim aimingOne;
    public Aim aimingTwo;
    public int selectedWeapon = 0;
    public GunFinal gun;
   // public CollisionDetection collisionDetection;
    public GameObject testing123;
    // Start is called before the first frame update

   
    void Start()
    {
       // testing123 = GameObject.FindGameObjectWithTag("Player");
      //  Debug.Log(testing123 + "This is the value of the test object");
      //  collisionDetection = GameObject.FindGameObjectWithTag("Player").GetComponent<CollisionDetection>();
        aimingOne = GameObject.FindGameObjectWithTag("Gun1").GetComponent<Aim>();
        aimingTwo = GameObject.FindGameObjectWithTag("Gun2").GetComponent<Aim>();

        //gun = GameObject.FindGameObjectWithTag("Gun2").GetComponent<GunFinal>();

        //Invoke("SelectWeapon", 2f);
        
        
        StartCoroutine(InitialSelect());

        
        
       
    }

    IEnumerator InitialSelect()
    {
        yield return new WaitUntil(() => aimingTwo.Crosshair != null);
        //SelectWeapon();
        Invoke("SelectWeapon", 0.1f);
        aimingOne.DisableCrosshair();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(1)==false)
        {
            //Debug.Log("why tf is this not working its a single if statement");
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

    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                gun = weapon.gameObject.GetComponent<GunFinal>();
                gun.initialAmmoResetCall();
                Debug.Log(weapon.gameObject + " SELECTED " + i);
                

            }
            else
            {
                weapon.gameObject.SetActive(false);
                Debug.Log(weapon.gameObject + " DISABLED " + i);
            }
            i++;
        }
    }
}
