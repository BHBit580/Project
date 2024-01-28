using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private float transitionTime = 1f;

    public void OnClickMenuButton()
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        int levelIndex = FindLevelIndex();

        transitionAnimator.SetTrigger("Start");
        SoundManager.instance.FadeOutMusic(transitionTime);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
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
                nextLevelToLoadIndex = 1;
            }
        }
        else
        {
            nextLevelToLoadIndex = 1;
        }
        
        return nextLevelToLoadIndex;
    }
}