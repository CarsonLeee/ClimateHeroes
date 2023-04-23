using UnityEngine;
using System.Collections.Generic;
using UnityEditor.VersionControl;

public class WaterEffect : MonoBehaviour
{
    public float waterRadius = 5f; // Radius to check for enemies within range
    public int damage = 1; // Amount of damage dealt to the enemy
    public string enemyTag = "Enemy"; // Tag assigned to enemy GameObjects
    private float damageInterval = 1f; // Interval between damage applications
    private Dictionary<GameObject, float> timeSinceLastDamage; // Dictionary to track time since last damage for each enemy

    void Start()
    {
        timeSinceLastDamage = new Dictionary<GameObject, float>();
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        foreach (GameObject enemy in enemies)
        {
            if (!timeSinceLastDamage.ContainsKey(enemy))
            {
                timeSinceLastDamage.Add(enemy, 0f);
            }

            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= waterRadius)
            {
                if (timeSinceLastDamage[enemy] >= damageInterval)
                {
                    EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(damage);
                    }
                    timeSinceLastDamage[enemy] = 0f;
                }
                else
                {
                    timeSinceLastDamage[enemy] += Time.deltaTime;
                }
            }
        }
    }
}

