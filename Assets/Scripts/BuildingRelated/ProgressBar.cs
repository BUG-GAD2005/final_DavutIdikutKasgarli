using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public float gametime;
    public float GetGold;
    public float GetGem;
    public TextMeshProUGUI textMesh;
    //private bool stopTimer;

    private float currentValue;

    void Start()
    {
        //stopTimer = false;
        slider.minValue = 0f;
        slider.maxValue = gametime;
        currentValue = 0f;
        slider.value = currentValue;
        textMesh.text = "";
    }

    void Update()
    {
        TimerCheck();
    }

    public void SetTargetValue(float target)
    {
        gametime = Mathf.Clamp(target, 0f, float.MaxValue);
        slider.maxValue = gametime;
    }
    void TimerCheck()
    {
        if (currentValue >= gametime)
        {
            
            CurrentMoney.CurrentGold += GetGold;
            CurrentMoney.CurrentGem += GetGem;
            currentValue = 0f;
            //gold will be yellow and gem purple write it in the textmesh
            StartCoroutine(TextTimer());
            Debug.Log("Time is up!");
            return;
        }

        if (currentValue < gametime)
        {
            currentValue += Time.deltaTime;
            slider.value = currentValue;
        }
    }
     private IEnumerator TextTimer()
    {
        Debug.Log("Action started");
        string goldText = "<color=yellow>" + GetGold.ToString();
        string plusText = "<color=blue>"+"+";
        string gemText = "<color=blue>" + GetGem.ToString();

        textMesh.text = "+" + goldText + plusText + gemText;
        yield return new WaitForSeconds(0.5f); 
        textMesh.text = "";
        Debug.Log("Delayed action");
    }
}
