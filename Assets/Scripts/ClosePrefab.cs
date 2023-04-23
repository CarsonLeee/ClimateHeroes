using UnityEngine;
using UnityEngine.UI;

public class ClosePrefab : MonoBehaviour
{
    public GameObject prefabToClose; // Assign the prefab you want to close in the Unity Editor

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ClosePrefabs);
    }

    void ClosePrefabs()
    {
        prefabToClose.SetActive(false);
    }
}