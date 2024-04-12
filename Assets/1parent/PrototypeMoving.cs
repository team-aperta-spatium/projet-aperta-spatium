using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeMoving : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public float rotationSpeed = 5f; // Adjust the rotation speed as needed

    private Quaternion initialRotation; // Store the initial rotation of the camera

    void Start()
    {
        initialRotation = transform.rotation; // Store the initial rotation of the camera
    }

    void Update()
    {
        // Move the camera based on keyboard input
        MoveCamera();

        // Rotate the camera based on mouse input
        RotateCamera();
    }

    private void MoveCamera()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move forward, backward, left, and right using mouse input
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;

        // Move upward using the S key
        movement += Input.GetKey(KeyCode.S) ? Vector3.up * moveSpeed * Time.deltaTime : Vector3.zero;

        transform.Translate(movement);
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Rotate around the y-axis for horizontal movement
        transform.Rotate(Vector3.up, mouseX);

        // Rotate around the x-axis for vertical movement
        transform.Rotate(Vector3.left, mouseY);

        // Clamp the rotation to avoid tilting upside down
        ClampCameraRotation();
    }

    private void ClampCameraRotation()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.z = 0; // Ensure camera doesn't roll

        // Clamp the camera rotation to avoid tilting upside down
        if (currentRotation.x > 80 && currentRotation.x < 180)
        {
            currentRotation.x = 80;
        }
        else if (currentRotation.x < 280 && currentRotation.x > 180)
        {
            currentRotation.x = 280;
        }

        transform.rotation = Quaternion.Euler(currentRotation);
    }
}
