using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BackGroundUI : MonoBehaviour
{
    [SerializeField] private float time = 0.5f;
    [SerializeField] private Vector2 finalPosVector;

    private void OnEnable()
    {
        Debug.Log(GetComponent<RectTransform>().transform.position);
        this.GetComponent<RectTransform>().DOAnchorPos(finalPosVector, time);
    }
}

