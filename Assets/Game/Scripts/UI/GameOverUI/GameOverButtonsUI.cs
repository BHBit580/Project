using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonsUI : MonoBehaviour
{
    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private float transitionTime = 1f;
    public void OnClickRestartButton()
    { 
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }
    
    public void OnClickNextLevelButton()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    
    IEnumerator LoadLevel(int levelIndex)
    {
        transitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
