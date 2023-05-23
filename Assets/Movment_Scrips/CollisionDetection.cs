using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GunFinal gunScriptOne;
    public GunFinal gunScriptTwo;
    public WeaponSwitching currentGun;

     //Start is called before the first frame update
    void Start()
    {
        //Invoke("test", 0.1f);
        test();
        currentGun = FindObjectOfType<WeaponSwitching>();
    }

    public void test()
    {
        gunScriptOne = GameObject.FindGameObjectWithTag("Gun1").GetComponent<GunFinal>();
        gunScriptTwo = GameObject.FindGameObjectWithTag("Gun2").GetComponent<GunFinal>();   
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            Debug.Log("Ammo picked up");
            Destroy(other.gameObject);
            if (currentGun.selectedWeapon == 0)
            {
                gunScriptOne.magazineCount++;
            }

            else
            {
                gunScriptTwo.magazineCount++;
            }

        }
        //Debug.Log(other.gameObject.tag);
    }
}
