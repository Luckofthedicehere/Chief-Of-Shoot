using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUnlocker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; //unlock the cursor
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
