using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DifferentClicks : MonoBehaviour, IPointerClickHandler {

    public GameManager gManage;
    public GameObject[] textVals;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            Debug.Log("left click");
        if (eventData.button == PointerEventData.InputButton.Middle)
            Debug.Log("middle click");
        if (eventData.button == PointerEventData.InputButton.Right)
            Debug.Log("right click");
        gManage.LoadOptionsMenu();
        
        createShape();
        
       
    }


    public void loadGunText(int val)
    {
        textVals[val].SetActive(true);
    }
    public void disableGunText()
    {
        for(int i = 0; i<textVals.Length; i++)
        {
            textVals[i].SetActive(false);
        }
    }

    public void getGunVal()
    {
        //???????
        
    }

    public void ButtonTest(Button btn)
    {
        Debug.Log(btn.name);
    }
   public void createShape()
    {
        string ClickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(ClickedButtonName); 
    }


    //get the value of the button that was right clicked
    //if statements to load text. use .enable based on the value

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
