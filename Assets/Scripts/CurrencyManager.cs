using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public int startingCurrency = 50;
    public Text currencyText;
    public Text notEnoughCurrencyText;

    private int currentCurrency;

    // Static instance of the CurrencyManager
    public static CurrencyManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        currentCurrency = startingCurrency;
        UpdateCurrencyText();
        notEnoughCurrencyText.gameObject.SetActive(false);
    }

    public bool CanAfford(int cost)
    {
        return currentCurrency >= cost;
    }

    public void SpendCurrency(int cost)
    {
        currentCurrency -= cost;
        UpdateCurrencyText();
    }

    public void ShowNotEnoughCurrencyMessage()
    {
        notEnoughCurrencyText.gameObject.SetActive(true);
        Invoke("HideNotEnoughCurrencyMessage", 2f);
    }

    private void UpdateCurrencyText()
    {
        currencyText.text = $"Currency: {currentCurrency}";
    }

    private void HideNotEnoughCurrencyMessage()
    {
        notEnoughCurrencyText.gameObject.SetActive(false);
    }
    public void AddCurrency(int amount)
    {
        currentCurrency += amount;
        UpdateCurrencyText();
    }
}