using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonsUI : MonoBehaviour
{
    public void OnClickRestartButton()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void OnClickNextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
