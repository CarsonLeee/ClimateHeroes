using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    private float spawnPosX = -9.18f;
    private float spawnPosZ = -0.874f;
    private float minY = -2.84f;
    private float maxY = 5.69f;
    private float spawnInterval = 5f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyToSpawn = enemyPrefabs[randomIndex];

        float spawnPosY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        Instantiate(enemyToSpawn, spawnPosition, enemyToSpawn.transform.rotation);
    }
}


