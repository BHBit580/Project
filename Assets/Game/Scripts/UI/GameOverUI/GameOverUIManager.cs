using System.IO;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO levelCompleted;
    [SerializeField] private GameObject backGroundUI;
    [SerializeField] private GameObject lastLevelText;
    [SerializeField] private GameObject uIElements;
    [SerializeField] private GameObject borders;
    
    private void Start()
    {
        backGroundUI.SetActive(false);
        lastLevelText.SetActive(false);
        uIElements.SetActive(false);
        borders.SetActive(false);
        levelCompleted.RegisterListener(SaveCurrentLevelData);
        levelCompleted.RegisterListener(EnableGameObjects);
    }
    
    
    private void EnableGameObjects()
    {
        Debug.Log("EnabledGameOverUI");
        borders.SetActive(true);
        backGroundUI.SetActive(true);
        if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            lastLevelText.SetActive(true);
            return;
        }
        
        uIElements.SetActive(true);
    }

    private void SaveCurrentLevelData()
    {
        PlayerPrefs.SetInt("LastPlayedLevel" , SceneManager.GetActiveScene().buildIndex);
    }
    
    
    private void OnDestroy()
    {
        levelCompleted.UnregisterListener(SaveCurrentLevelData);
        levelCompleted.UnregisterListener(EnableGameObjects);
    }
    
}