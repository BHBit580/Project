using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class AdjustWallScale : MonoBehaviour
{
    [SerializeField] private Transform leftBorder , rightBorder;
    [SerializeField] private OrbElement orbElement;
    [SerializeField] private VoidEventChannelSO collectOrbLevelPopUpUI;
    [SerializeField] private float multiplier = 1f;
    private void Update()
    {
        float distance = Vector3.Distance(leftBorder.position , rightBorder.position);
        transform.localScale = new Vector3(distance , transform.localScale.y , transform.localScale.z) * multiplier;
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && orbElement.nofOfOrbs > 0)
        {
            collectOrbLevelPopUpUI.RaiseEvent();
        }
    }
}
