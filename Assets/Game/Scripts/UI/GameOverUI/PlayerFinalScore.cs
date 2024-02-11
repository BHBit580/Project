using TMPro;
using UnityEngine;

public class PlayerFinalScore : MonoBehaviour
{
    [SerializeField] private DisplayCurrentTime displayCurrentTime; 
    private TextMeshProUGUI _currentScore;
    
    private void OnEnable()
    {
        _currentScore = GetComponent<TextMeshProUGUI>();
        string currentTimeText = displayCurrentTime.GetCurrentTimeText().text;
        _currentScore.text = currentTimeText + "<size=45%>s</size>";
    }
}
