using System.IO;
using EasyTransition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private TransitionSettings transitionSettings;
    [SerializeField] private float transitionTime = 1f;

    public void OnClickMenuButton()
    {
        int nextLevelToLoadIndex = FindLevelIndex();
        TransitionManager.Instance().Transition(nextLevelToLoadIndex , transitionSettings , transitionTime);
    }
    
    private int FindLevelIndex()
    {
        string filePath = Path.Combine(Application.dataPath, "LastPlayedLevel.json");
        int nextLevelToLoadIndex;

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath); 
            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);
            nextLevelToLoadIndex = loadedData.lastPlayedLevel + 1;
            
            if (nextLevelToLoadIndex >= SceneManager.sceneCountInBuildSettings)
            {
                nextLevelToLoadIndex = 2;
            }
        }
        else
        {
            nextLevelToLoadIndex = 2;
        }
        
        return nextLevelToLoadIndex;
    }
}