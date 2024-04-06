using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab; // Prefab of the first falling ball
    public GameObject ballPrefab2; // Prefab of the second falling ball
    public Transform[] spawnPoints; // Array of spawn points where the balls will be spawned
    public float spawnInterval = 1.5f; // Interval between each ball spawn
    public float fallingSpeed = 5f; // Speed at which the balls fall
    public float duration = 30f; // Duration for which balls will fall
    private float timer; // Timer to track the duration
    private bool isFalling = true; // Flag to control falling state
    public Text timerText;
    private int playerLives = 3; // Initial player lives
    private int playerScore = 0; // Initial player score
    public Text livesText;
    public Text scoreText;

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
                EndGame();
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
            if (Time.time % spawnInterval < Time.deltaTime)
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

    public void ReduceLives()
    {
        playerLives--;
        UpdateUI();
    }

    public void IncreaseScore()
    {
        playerScore++;
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
        if (livesText != null && scoreText != null)
        {
            livesText.text = "Lives: " + playerLives.ToString();
            scoreText.text = "Score: " + playerScore.ToString();
        }
    }

    void EndGame()
    {
        // Load PlayFab scene when the game ends
        SceneManager.LoadScene("PlayFab");
    }
}
