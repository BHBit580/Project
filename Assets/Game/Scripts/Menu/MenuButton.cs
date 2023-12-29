using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private RectTransform levelSelector;
    [SerializeField] private RectTransform gameTitle;
    [SerializeField] private Vector2 finalGamePosVector;
    [SerializeField] private Vector2 finalPosVector = new Vector2(-10 , -580);
    [SerializeField] private Vector2 finalPosButtonVector;
    [SerializeField] private float time = 0.25f;
    
    private bool isLevelSelectionOpen = false;

    private void Start()
    {
        isLevelSelectionOpen = false;
    }

    public void OnClickMenuButton()
    {
        if (isLevelSelectionOpen == false)
        {
            gameTitle.DOAnchorPos(finalGamePosVector, time);
            levelSelector.DOAnchorPos(finalPosVector, time);
            GetComponent<RectTransform>().DOAnchorPos(finalPosButtonVector, time);
            isLevelSelectionOpen = true;
        }
    }
    
    
}
