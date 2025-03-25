using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;  // 3D Rigidbody

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float minVelocity = 0.1f;

    private Vector2 input;

    void Update()
    {
        // Get raw input (-1, 0, or 1)
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Update animator parameters for direction
        if (input != Vector2.zero)
        {
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);
        }
    }

    void FixedUpdate()
    {
        // Convert 2D input to a 3D vector (X, 0, Z)
        Vector3 velocity = new Vector3(input.x, 0f, input.y) * moveSpeed;

        // Apply velocity to a 3D Rigidbody
        rb.linearVelocity = velocity;

        // Check if velocity magnitude is above minVelocity
        if (velocity.magnitude > minVelocity)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
