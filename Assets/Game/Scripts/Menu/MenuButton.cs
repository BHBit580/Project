using System;
using System.Collections;
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
    [SerializeField] private LevelSelector levelSelectorScript;
    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private float transitionTime = 1f;
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
        else
        {
            StartCoroutine(LoadLevel(levelSelectorScript.selectedLevelNumber));
        }
    }
    
    IEnumerator LoadLevel(int levelIndex)
    {
        transitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
    
    
}
