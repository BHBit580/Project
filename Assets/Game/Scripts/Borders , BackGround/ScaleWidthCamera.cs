using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScaleWidthCamera : MonoBehaviour
{
    [SerializeField] private int targetWidth = 1920;
    [SerializeField] private float pixelsToUnits = 100;

    private void Update()
    {
        int height = Mathf.RoundToInt(targetWidth / (float)Screen.width * Screen.height);
        Camera.main.orthographicSize = height / pixelsToUnits / 2;
    }
}