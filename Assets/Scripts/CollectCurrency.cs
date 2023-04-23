using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectCurrency : MonoBehaviour
{
    public int currencyValue = 10; // The amount of currency to add when the prefab is clicked

    public void OnMouseDown()
    {
        CurrencyManager.Instance.AddCurrency(currencyValue);
    }
}