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

    private float currentRotation = 0f; // Tracks the current rotation angle
    private bool isRotating = false; // Tracks if the button is pressed

    [Header("UI Button")]
    [SerializeField] private Button rotateButton; // The UI Button to trigger rotation

    void Start()
    {
        // Register the button click event listeners
        rotateButton.onClick.AddListener(() => StartRotation());
    }

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
    }

    private void StartRotation()
    {
        isRotating = true;

        // Stop rotation after a short delay to mimic button press
        Invoke(nameof(StopRotation), 1f); // Adjust duration as needed
    }

    private void StopRotation()
    {
        isRotating = false;
    }
}
