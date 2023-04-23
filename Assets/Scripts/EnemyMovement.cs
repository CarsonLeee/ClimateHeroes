using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public GameObject gameOverPrefab; // Assign the Game Over prefab in the Unity Editor

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Check if the position is less than -50 in the x direction
        if (transform.position.x < -50f)
        {
            // Instantiate the Game Over prefab at a desired position
            Instantiate(gameOverPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Destroy(gameObject);

            // Optional: Stop the game or perform other actions
        }
    }
}