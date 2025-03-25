using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;  // Optional if using Rigidbody2D movement

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
        // Move the player in FixedUpdate if using a Rigidbody2D
        // (Alternatively, you could do transform.Translate in Update if you prefer.)
        Vector2 velocity = input.normalized * moveSpeed;
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
