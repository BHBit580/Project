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
        GameData gameData = new GameData();
        gameData.lastPlayedLevel = SceneManager.GetActiveScene().buildIndex;

        string dataAsJson = JsonUtility.ToJson(gameData , true);
        
        File.WriteAllText(Application.dataPath + "/LastPlayedLevel.json", dataAsJson);
    }
    
    
    private void OnDestroy()
    {
        levelCompleted.UnregisterListener(SaveCurrentLevelData);
        levelCompleted.UnregisterListener(EnableGameObjects);
    }
    
}