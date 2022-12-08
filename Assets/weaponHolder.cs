using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponHolder : MonoBehaviour
{



    public FindGun gunFind;

    public GameObject[] gunPrefabs;

    void Start()
    {
        destroyChildren();
    }
    void destroyChildren()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    void loadNewChildren()
    {
        
    }

    public void findCorrectGun()
    {
        for (int i = 0; i < gunPrefabs.Length; i++);
        {
            if(gunPrefabs[i].name == selected)
            {
                GameObject gun1 = Resources.Load(selected) as GameObject;
                GameObject theFirstGun = Instantiate(gun1);
                Transform newParent = GameObject.FindWithTag("WeaponHolder").GetComponent<Transform>();
                theFirstGun.transform.SetParent(newParent, false);
            }
        } 
    }


}
