using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTest : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float jumpForce = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Rotation with mouse
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Clamp the player's position to stay within bounds (optional)
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -10f, 10f); // Adjust the range as needed
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, -10f, 10f); // Adjust the range as needed
        transform.position = clampedPosition;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}

