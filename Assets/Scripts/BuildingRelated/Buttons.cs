using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Buttons : MonoBehaviour
{
    public Button newButton;
    EventTrigger eventTrigger;
    public int neededGold;
    public int neededGem;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI gemText;
    // Start is called before the first frame update
    void Start()
    {
        eventTrigger = newButton.GetComponent<EventTrigger>();
        SetInteract(false);
        goldText.text = neededGold.ToString();
        gemText.text = neededGem.ToString();
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
    public void SetInteract(bool boolValue)
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
