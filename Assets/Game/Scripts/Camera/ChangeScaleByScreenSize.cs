using System;
using UnityEngine;

[ExecuteInEditMode]
public class ChangeScaleByScreenSize : MonoBehaviour
{
    private Transform leftBorder; 
    private Transform rightBorder;
    
    private float _scaleX;

    private void Start()
    {
        leftBorder = GameObject.FindGameObjectWithTag("LeftBorder").transform;
        rightBorder = GameObject.FindGameObjectWithTag("RightBorder").transform;
    }

    private void Update() => ScaleObject();

    void ScaleObject()
    {
        _scaleX = rightBorder.position.x - leftBorder.position.x;
        transform.localScale = new Vector3(_scaleX, transform.localScale.y, transform.localScale.z);
    }
    
}