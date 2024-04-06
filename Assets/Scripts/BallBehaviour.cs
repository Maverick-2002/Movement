using UnityEngine;

public class BallClickHandler : MonoBehaviour
{
    public bool isBall1; // Set to true if this is ball1, false if it's ball2
    private BallSpawner ballSpawner; // Reference to the BallSpawner script

    void Start()
    {
        // Find the BallSpawner script in the scene
        ballSpawner = FindObjectOfType<BallSpawner>();
    }

    void OnMouseDown()
    {
        if (isBall1)
        {
            // Reduce player lives when clicking ball1
            ballSpawner.ReduceLives();
        }
        else
        {
            // Increase player score when clicking ball2
            ballSpawner.IncreaseScore();
        }

        // Destroy the ball
        Destroy(gameObject);
    }
}
