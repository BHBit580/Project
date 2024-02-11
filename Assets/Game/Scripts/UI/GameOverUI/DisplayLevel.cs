using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayLevel : MonoBehaviour
{
    private TextMeshProUGUI _displayLevel;

    private void OnEnable()
    {
        _displayLevel = GetComponent<TextMeshProUGUI>();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex-1;
        _displayLevel.text = $"Level - {currentSceneIndex}";
    }



}
