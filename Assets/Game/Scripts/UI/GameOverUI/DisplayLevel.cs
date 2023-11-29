using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayLevel : MonoBehaviour
{
    private TextMeshProUGUI _displayLevel;

    private void Start()
    {
        _displayLevel = GetComponent<TextMeshProUGUI>();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        _displayLevel.text = $"Level - {currentSceneIndex}";
    }



}
