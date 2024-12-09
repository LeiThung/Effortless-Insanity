using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCController : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of rotation when a key is pressed
    private float currentRotation = 0f; // Keep track of the current rotation

    void Update()
    {
        // Rotate when pressing keys
        if (Input.GetKey(KeyCode.A)) // Rotate left
        {
            currentRotation -= rotationSpeed * Time.deltaTime; // Decrease the current rotation
        }

        if (Input.GetKey(KeyCode.D)) // Rotate right
        {
            currentRotation += rotationSpeed * Time.deltaTime; // Increase the current rotation
        }

        // Apply the rotation to the object around its local z-axis
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }
}
