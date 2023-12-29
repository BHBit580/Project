using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class AdjustWallScale : MonoBehaviour
{
    [SerializeField] private Transform leftBorder , rightBorder;
    [SerializeField] private float multiplier = 1f;
    private void Update()
    {
        float distance = Vector3.Distance(leftBorder.position , rightBorder.position);
        transform.localScale = new Vector3(distance , transform.localScale.y , transform.localScale.z) * multiplier;
    }
}
