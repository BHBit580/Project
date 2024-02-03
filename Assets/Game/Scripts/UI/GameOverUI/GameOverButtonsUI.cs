using EasyTransition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonsUI : MonoBehaviour
{
    [SerializeField] private TransitionSettings transitionSettings;
    [SerializeField] private float transitionTime = 1f;
    
    public void OnClickRestartButton()
    { 
        LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void OnClickNextLevelButton()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    private void LoadLevel(int levelIndex)
    {
        TransitionManager.Instance().Transition(levelIndex , transitionSettings , transitionTime);
    }
}
