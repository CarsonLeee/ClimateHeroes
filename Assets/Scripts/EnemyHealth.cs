using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public GameObject canvasPrefab; // Reference to the canvas prefab with text
    public string[] phrases = new string[10]; // Array of 10 phrases

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // Instantiate the canvas with randomized text
            GameObject canvasInstance = Instantiate(canvasPrefab, transform.position, Quaternion.identity);
            Text textComponent = canvasInstance.GetComponentInChildren<Text>();

            if (textComponent != null)
            {
                int randomIndex = Random.Range(0, phrases.Length);
                textComponent.text = phrases[randomIndex];
            }

            // You can add custom actions for when the enemy's health reaches 0, such as destroying the enemy
            CurrencyManager.Instance.AddCurrency(10);
            Destroy(gameObject);
        }
    }
}
