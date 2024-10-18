using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab; // The ball prefab to instantiate
    public Stage currentStage; // Reference to the current stage scriptable object
    public Transform spawnPoint; // Where the balls will spawn

    private List<GameObject> balls = new List<GameObject>(); // To keep track of all spawned balls

    void Start()
    {
        if (currentStage.ballCount != 1){
            SpawnBalls(); // Spawn balls at the start of the game
        }
    }

    // Method to spawn balls based on the ballCount from Stage
    public void SpawnBalls()
    {
        for (int i = 0; i < currentStage.ballCount; i++)
        {
            // Instantiate a new ball at the spawn point with some offset
            Vector3 spawnPosition = spawnPoint.position + new Vector3(i * 2.0f, 0, 0); // Offset to prevent overlapping
            GameObject newBall = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);

            // Optionally, set up the ball color from the stage
            newBall.GetComponent<Renderer>().material.color = currentStage.stageBallColor;

            balls.Add(newBall); // Add to the list of balls for later reference
        }
    }

    // Optionally, a method to reset all balls
    public void ResetBalls()
    {
        foreach (GameObject ball in balls)
        {
            ball.GetComponent<BallController>().ResetBall(); // Reset each ball individually
        }
    }
}
