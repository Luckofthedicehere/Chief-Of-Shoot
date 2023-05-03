using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HenryRifle : MonoBehaviour, IPointerClickHandler
{
    public GameManager gManage;
    public DifferentClicks dClicks;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            gManage.LoadOptionsMenu();
            dClicks.disableGunText();
            dClicks.loadGunText(0);
        }


    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
