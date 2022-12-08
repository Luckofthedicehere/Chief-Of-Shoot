using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GunFinal gunScriptOne;
    public WeaponSwitching currentGun;

    // Start is called before the first frame update
    void Start()
    {
        currentGun = FindObjectOfType<WeaponSwitching>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            Debug.Log("Ammo picked up");
            if (currentGun.selectedWeapon == 0)
            {

            }

        }
        Debug.Log(other.gameObject.tag);
    }
}
