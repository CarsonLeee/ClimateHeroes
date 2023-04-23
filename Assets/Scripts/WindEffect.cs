using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WindEffect : MonoBehaviour
{
    public float windRadius = 2f; // Radius to check for enemies within range
    public float windForce = 3f; // Speed at which the enemy is pushed back
    public string enemyTag = "Enemy"; // Tag assigned to enemy GameObjects
    public float pushbackDuration = 3f; // Duration of the pushback effect

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        foreach (GameObject enemy in enemies)
        {
            EnemyPushCount enemyPushCount = enemy.GetComponent<EnemyPushCount>();
            if (enemyPushCount == null)
            {
                enemyPushCount = enemy.AddComponent<EnemyPushCount>();
            }

            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= windRadius && enemyPushCount.pushCount < 2 && enemy.transform.position.x > transform.position.x)
            {
                enemyPushCount.pushCount++;
                StartCoroutine(PushBack(enemy));
            }
        }
    }

    IEnumerator PushBack(GameObject enemy)
    {
        float startTime = Time.time;

        while (Time.time - startTime < pushbackDuration)
        {
            enemy.transform.position += Vector3.right * windForce * Time.deltaTime;
            yield return null;
        }
    }
}

public class EnemyPushCount : MonoBehaviour
{
    public int pushCount = 0;
}