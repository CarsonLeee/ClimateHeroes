using System.Collections;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    // Public variable to assign the prefab in the Inspector
    public GameObject prefab;

    // Time interval for instantiation
    public float interval = 3.0f;

    // yOffset relative to the parent object
    public float yOffset = 1.698f;

    // Time delay before destroying the instantiated prefab
    public float destroyDelay = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        // Start the InstantiateCoroutine coroutine
        StartCoroutine(InstantiateCoroutine());
    }

    IEnumerator InstantiateCoroutine()
    {
        // Infinite loop
        while (true)
        {
            // Instantiate the prefab with the specified y-coordinate relative to the parent object,
            // and set the parent object as the prefab's parent
            Vector3 position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
            GameObject instance = Instantiate(prefab, position, transform.rotation);
            instance.transform.SetParent(transform);
            if(gameObject.CompareTag("Solar"))
            {
                CurrencyManager.Instance.AddCurrency(10);
            }

            // Destroy the instantiated prefab after the specified delay
            Destroy(instance, destroyDelay);

            // Wait for the specified interval
            yield return new WaitForSeconds(interval);
        }
    }
}