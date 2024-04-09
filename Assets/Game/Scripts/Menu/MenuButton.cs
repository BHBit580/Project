using System.Collections;
using System.IO;
using EasyTransition;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private TransitionSettings transitionSettings;
    [SerializeField] private float transitionTime = 1f;
    int nextLevelToLoadIndex;


    public void OnClickMenuButton()
    {
        int nextLevelToLoadIndex = FindLevelIndex();
        TransitionManager.Instance().Transition(nextLevelToLoadIndex , transitionSettings , transitionTime);
    }
    
    private int FindLevelIndex()
    {
        if (PlayerPrefs.HasKey("LastPlayedLevel"))
        {
            int lastPlayedLevel = PlayerPrefs.GetInt("LastPlayedLevel");
            nextLevelToLoadIndex = lastPlayedLevel + 1;

            if (nextLevelToLoadIndex >= SceneManager.sceneCountInBuildSettings)
            {
                nextLevelToLoadIndex = 2;
            }
        }
        else
        {
            PlayerPrefs.SetInt("LastPlayedLevel" , 2);
            nextLevelToLoadIndex = 2;
        }

        return nextLevelToLoadIndex;
    }

    
}