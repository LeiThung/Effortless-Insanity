using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Slider rotationSlider;  // Reference to the slider
    [SerializeField] private float rotationSpeed = 360f;  // Rotation speed in degrees per second

    void Update()
    {
        // You can also update rotation based on slider in real-time (if necessary).
        // If you want it to be controlled through the slider only, the line below isn't necessary.
        // Rotate the object based on the slider value.
        if (rotationSlider != null)
        {
            float zRotation = rotationSlider.value * rotationSpeed;  // Adjust rotation value based on slider
            transform.rotation = Quaternion.Euler(0f, 0f, zRotation);  // Apply rotation to Z-axis
        }
    }

    // Method to handle slider value changes
    public void OnSliderValueChanged(float value)
    {
        // Calculate the new rotation based on slider value
        float zRotation = value * rotationSpeed;
        transform.rotation = Quaternion.Euler(0f, 0f, zRotation);  // Rotate only on the Z-axis
    }
}
