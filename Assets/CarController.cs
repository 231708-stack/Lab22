using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleCarController : MonoBehaviour
{
    public float speed = 10f;          // Forward/backward speed
    public float turnSpeed = 50f;      // Turning speed
    public float jumpForce = 300f;     // Force applied for jumping
    public LayerMask groundLayer;      // Layer(s) considered ground
    public float groundCheckDistance = 0.5f;  // Distance for ground check

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get input from arrow keys or WASD
        float moveInput = Input.GetAxis("Vertical");   // Up/Down arrows
        float turnInput = Input.GetAxis("Horizontal"); // Left/Right arrows

        // Move forward/backward
        Vector3 move = transform.forward * moveInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        // Rotate left/right
        float turn = turnInput * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    void Update()
    {
        CheckGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void CheckGrounded()
    {
        // Raycast down to check if the car is on the ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }
}
