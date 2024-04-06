using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from arrow keys or WASD keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Normalize movement vector to prevent faster diagonal movement
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        // Move the player
        rb.MovePosition(transform.position + transform.TransformDirection(movement));
    }
}
