using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClicktoInstantiate : MonoBehaviour
{
    public GameObject[] prefabs;
    public Toggle[] toggles;
    private Camera mainCamera;
    public float distanceFromCamera = 15f;
    public float maxYPosition = 8f;
    public CurrencyManager currencyManager;
    public int[] prefabCosts = { 10, 30, 20 };

    void Start()
    {
        mainCamera = Camera.main;
        currencyManager = CurrencyManager.Instance;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Check if a UI element is being clicked and return early if it is
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = distanceFromCamera;
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);

            if (worldPos.y <= maxYPosition)
            {
                for (int i = 0; i < toggles.Length; i++)
                {
                    if (toggles[i].isOn)
                    {
                        if (currencyManager.CanAfford(prefabCosts[i]))
                        {
                            Quaternion rotation = Quaternion.Euler(0, 90f, 0);
                            Instantiate(prefabs[i], worldPos, rotation);
                            currencyManager.SpendCurrency(prefabCosts[i]);
                        }
                        else
                        {
                            currencyManager.ShowNotEnoughCurrencyMessage();
                        }

                        break;
                    }
                }
            }
        }
    }
}

