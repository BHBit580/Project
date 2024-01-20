using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AllOrbNotCollectedPopUp : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO collectOrbLevelPopUpUI;
    [SerializeField] private GameObject collectAllOrbsPopUp;
    [SerializeField] private float timeToPopUp = 1.2f;
    
    private void OnEnable()
    {
        collectOrbLevelPopUpUI.RegisterListener(PopUpUI);
    }

    private void Start()=> collectAllOrbsPopUp.SetActive(false);

    private void PopUpUI()
    {
        StartCoroutine(InstantiateCollectAllOrbsPopUp());
    }
    
    private IEnumerator InstantiateCollectAllOrbsPopUp()
    {
        collectAllOrbsPopUp.SetActive(true);
        TextMeshProUGUI popUpTextComponent = collectAllOrbsPopUp.GetComponent<TextMeshProUGUI>();

        float elapsedTime = 0f;

        while (elapsedTime < timeToPopUp)
        {
            popUpTextComponent.color = new Color(popUpTextComponent.color.r, popUpTextComponent.color.g, popUpTextComponent.color.b, 1 - (elapsedTime / timeToPopUp));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        collectAllOrbsPopUp.SetActive(false);
    }

    
    private void OnDisable()
    {
        collectOrbLevelPopUpUI.UnregisterListener(PopUpUI);
    }
    
    
}
