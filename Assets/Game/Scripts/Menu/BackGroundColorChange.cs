using UnityEngine;
using UnityEngine.UI;

public class BackgroundColorChange : MonoBehaviour
{
    public float colorChangeSpeed = 1f; // Speed of color change
    public float colorChangeIntensity = 1f; // Intensity of color change effect

    private Image backgroundImage; // Reference to the Image component
    private Color targetColor; // Target color for the transition
    private Color initialColor; // Initial color of the background
    private float blendStartTime; // Time when the blend started

    void Start()
    {
        backgroundImage = GetComponent<Image>(); // Get the Image component attached to the same GameObject
        initialColor = backgroundImage.color; // Get the initial background color
        targetColor = GetRandomColor(); // Set the initial target color
        blendStartTime = Time.time; // Record the start time of the blend
    }

    void Update()
    {
        float elapsedTime = Time.time - blendStartTime; // Calculate elapsed time

        // Calculate the blend factor based on elapsed time and colorChangeSpeed
        float blendFactor = Mathf.Clamp01(elapsedTime / colorChangeSpeed);

        // Use Color.Lerp to smoothly transition between initialColor and targetColor
        backgroundImage.color = Color.Lerp(initialColor, targetColor, blendFactor * colorChangeIntensity);

        // If the blend is complete, set a new target color and reset the blendStartTime
        if (blendFactor >= 1f)
        {
            initialColor = targetColor;
            targetColor = GetRandomColor();
            blendStartTime = Time.time;
        }
    }

    // Helper function to generate a random vibrant color
    private Color GetRandomColor() 
    {
        return new Color(Random.Range(0.3f, 1f), Random.Range(0.3f, 1f), Random.Range(0.3f, 1f));
    }
}