using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust as needed
    public float rotationSpeed = 100f; // Adjust as needed

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Freeze rotation to prevent unwanted tilting
    }

    void Update()
    {
        // Get input from keyboard or joystick
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // If there's any movement input
        if (moveDirection.magnitude >= 0.1f)
        {
            EventManager.EmitEvent("KeysPressed");
            // Calculate rotation towards movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Calculate movement velocity
            Vector3 moveVelocity = moveDirection * moveSpeed;

            // Apply movement to the rigidbody
            rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);
        }
        else
        {
            // If no movement input, stop the player
            rb.velocity = Vector3.zero;
        }
    }
}