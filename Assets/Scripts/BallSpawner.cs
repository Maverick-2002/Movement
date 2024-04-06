using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using TMPro;
using PlayFab;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject ballPrefab2;
    public Transform[] spawnPoints;
    public float initialSpawnInterval = 1.5f;
    public float fallingSpeed = 5f;
    public float duration = 30f;
    private float timer;
    private bool isFalling = true;
    public Text timerText;
    public int playerLives = 3;
    public int playerScore = 0;
    public int level = 1;
    public int GoodObjectPicked = 0;
    public int BadObjectPicked = 0;
    public Text livesText;
    public Text scoreText;
    public Text levelText;

    void Start()
    {
        // Set initial timer value
        timer = duration;
        UpdateUI();
    }

    void Update()
    {
        if (isFalling)
        {
            timer -= Time.deltaTime;

            // Update the UI text
            UpdateTimerUI();

            // Check if the timer reaches zero
            if (timer <= 0)
            {
                isFalling = false;
                ProceedToNextLevel();
            }
        }

        // Stop the game if player lives reach 0
        if (playerLives <= 0)
        {
            isFalling = false;
            EndGame();
        }

        // Spawn balls continuously while falling is true
        if (isFalling && timer >= 0)
        {
            if (Time.time % GetSpawnInterval() < Time.deltaTime)
            {
                // Get a random spawn point index
                int randomSpawnIndex = Random.Range(0, spawnPoints.Length);

                // Instantiate two balls at the random position
                GameObject ball = Instantiate(ballPrefab, spawnPoints[randomSpawnIndex].position, Quaternion.identity);
                GameObject ball2 = Instantiate(ballPrefab2, spawnPoints[randomSpawnIndex].position, Quaternion.identity);

                // Apply downward force to make the balls fall
                Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
                Rigidbody ballRigidbody2 = ball2.GetComponent<Rigidbody>();
                if (ballRigidbody != null && ballRigidbody2 != null)
                {
                    ballRigidbody.velocity = Vector3.down * fallingSpeed;
                    ballRigidbody2.velocity = Vector3.down * fallingSpeed;
                }
            }
        }
    }

    float GetSpawnInterval()
    {
        // Adjust spawn interval based on level
        return initialSpawnInterval - (level * 0.25f); // Decrease spawn interval by 0.25 each level
    }

    public void ReduceLives()
    {
        playerLives--;
        BadObjectPicked++;
        UpdateUI();
    }

    public void IncreaseScore()
    {
        playerScore++;
        GoodObjectPicked++;
        UpdateUI();
    }

    public void IncreaseLevel()
    {
        level++;
        UpdateUI();
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.CeilToInt(timer).ToString();
        }
    }

    void UpdateUI()
    {
        if (livesText != null && scoreText != null && levelText != null)
        {
            livesText.text = "Lives: " + playerLives.ToString();
            scoreText.text = "Score: " + playerScore.ToString();
            levelText.text = "Level: " + level.ToString();
        }
    }

    void ProceedToNextLevel()
    {
        // Increment level and reset timer for the next level
        IncreaseLevel();
        timer = duration;
        isFalling = true;
    }

    void EndGame()
    {
        // Implement end game logic here
        Debug.Log("Game Over!");
    }

  


}
