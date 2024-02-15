using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ScaleWithScreenSize : MonoBehaviour
{
    [SerializeField] private int targetWidth = 1080;
    [SerializeField] private float pixelsToUnits = 50;

    private void Update()
    {
        int height = Mathf.RoundToInt(targetWidth / (float)Screen.width * Screen.height);
        Camera.main.orthographicSize = height / pixelsToUnits / 2;
    }
}
