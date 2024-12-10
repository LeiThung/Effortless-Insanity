using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swinger : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private Transform pivotPoint; // The point to rotate around
    [SerializeField] private float rotationSpeed = 10f; // Speed of rotation
    [SerializeField] private float targetRotationAngle = 30f; // Angle to rotate when button is pressed
    [SerializeField] private float force = 2;

    private float currentRotation = 0f; // Tracks the current rotation angle
    private bool isRotating = false; // Tracks if the button is pressed


    void Update()
    {
        // Determine the target rotation angle
        float targetRotation = isRotating ? targetRotationAngle : 0f;

        // Smoothly rotate towards the target rotation
        float rotationDelta = Mathf.MoveTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Apply rotation around the pivot point
        transform.RotateAround(pivotPoint.position, Vector3.forward, rotationDelta - currentRotation);

        // Update the current rotation
        currentRotation = rotationDelta;

        // Reset rotation state when target is reached
        if (!isRotating && Mathf.Approximately(currentRotation, 0f))
        {
            currentRotation = 0f; // Ensures it doesn't overshoot
        }

        if(Input.GetKeyDown(KeyCode.Space)) StartRotation();
    }

    private void StartRotation()
    {
        isRotating = true;

        // Stop rotation after a short delay to mimic button press
        Invoke(nameof(StopRotation), 0.5f); // Adjust duration as needed
    }

    private void StopRotation()
    {
        isRotating = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && isRotating)
        {
            Rigidbody rb = collision.rigidbody;
            if (rb != null)
            {
                // Apply a force to the ball in the direction of the swing
                Vector3 forceDirection = transform.up.normalized; // Direction perpendicular to the swinging object
                rb.AddForce(forceDirection * force, ForceMode.Impulse);
            }
        }
    }
}
