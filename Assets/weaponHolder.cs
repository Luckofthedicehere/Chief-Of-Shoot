using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponHolder : MonoBehaviour
{

    //useless script

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

  


}
