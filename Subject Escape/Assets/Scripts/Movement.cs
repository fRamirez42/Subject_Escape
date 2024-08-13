using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkSpeed = 5f;       // Walking speed
    public float runSpeed = 10f;       // Running speed
    public float mouseSensitivity = 200f; // Mouse sensitivity
    public Transform playerCamera;     // Reference to the player's camera

    private float currentSpeed;        // Current movement speed
    private Vector3 moveDirection;     // Movement direction
    private float xRotation = 0f;      // Vertical rotation of the camera

    // Start is called before the first frame update
    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse look for rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate player horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Rotate camera vertically
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevents over-rotation
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Get input for movement
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down arrow keys

        // Determine if the player is holding the Shift key to run
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed = runSpeed;  // Set speed to running speed
        }
        else
        {
            currentSpeed = walkSpeed; // Set speed to walking speed
        }

        // Calculate movement direction relative to the player's forward direction
        moveDirection = transform.right * moveX + transform.forward * moveZ;

        // Move the player
        transform.position += moveDirection * currentSpeed * Time.deltaTime;
    }
}
