using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float smoothing = 0.1f; // How much to smooth the accelerometer input
    public float maxTiltAngle = 90f; // Maximum tilt angle (degrees) on each axis
    public float rotationSpeed = 5f; // Speed of the rotation (higher means faster rotation)
    private Vector3 smoothedAcceleration; // Smoothed accelerometer value

    void Start()
    {
        // Initialize the smoothed acceleration to the current acceleration
        smoothedAcceleration = Input.acceleration;
    }

    void Update()
    {
        // Smooth the accelerometer input using a low-pass filter
        smoothedAcceleration = Vector3.Lerp(smoothedAcceleration, Input.acceleration, smoothing);

        // Map the accelerometer values to tilt angles
        float tiltX = Mathf.Clamp(smoothedAcceleration.x * maxTiltAngle, -maxTiltAngle, maxTiltAngle);
        //float tiltZ = Mathf.Clamp(smoothedAcceleration.y * maxTiltAngle, -maxTiltAngle, maxTiltAngle);

        // Smoothly apply the tilt to the object with rotation speed
        float targetRotation = -tiltX;
        float currentRotation = transform.rotation.eulerAngles.z;

        // Smoothly interpolate the rotation to avoid fast snapping
        float smoothRotation = Mathf.LerpAngle(currentRotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Apply the smooth rotation to the object
        transform.rotation = Quaternion.Euler(0, 0f, smoothRotation);
    }
}
