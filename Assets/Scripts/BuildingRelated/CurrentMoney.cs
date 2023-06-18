using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum CurrencyType
{
    Gold,
    Gem
}
public class CurrentMoney : MonoBehaviour
{
    //public TextMeshPro 
    public TextMeshProUGUI textMesh;
    [SerializeField] private CurrencyType currencyType;
    static public float CurrentGold;
    static public float CurrentGem;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currencyType == CurrencyType.Gold)
        {
            textMesh.text = CurrentGold.ToString();
        }
        else if (currencyType == CurrencyType.Gem)
        {
            textMesh.text = CurrentGem.ToString();
        }
    }
}
