using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour
{
    public Button newButton;
    EventTrigger eventTrigger;
    public int neededGold;
    public int neededGem;
    // Start is called before the first frame update
    void Start()
    {
        eventTrigger = newButton.GetComponent<EventTrigger>();
        SetInteract(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteractable();
        //if pointer enter == true

    }
    void CheckInteractable()
    {
        if(CurrentMoney.CurrentGold >= neededGold && CurrentMoney.CurrentGem >= neededGem)
        {
            SetInteract(true);           
        }
        else
        {
            SetInteract(false);
        }
    }
    void SetInteract(bool boolValue)
    {
        newButton.interactable = boolValue;
       //disable trigger functions

        eventTrigger.enabled = boolValue;

    }
    public void PayTheValue()
    {
        CurrentMoney.CurrentGold -= neededGold;
        CurrentMoney.CurrentGem -= neededGem;
    }
}
