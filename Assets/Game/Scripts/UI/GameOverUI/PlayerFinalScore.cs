using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerFinalScore : MonoBehaviour
{
    [SerializeField] private DisplayCurrentTime displayCurrentTime; 
    private TextMeshProUGUI _currentScore;
    
    private void Start()
    {
        _currentScore = GetComponent<TextMeshProUGUI>();
        _currentScore.text = displayCurrentTime.GetCurrentTimeText().text + "s";
    }
}
