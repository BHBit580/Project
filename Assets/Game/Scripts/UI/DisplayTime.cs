using TMPro;
using UnityEngine;

public class DisplayTime : MonoBehaviour
{
    //[SerializeField] private VoidEventChannelSO playerStartedGame;
    
    public TextMeshProUGUI timeText;

    private void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        DisplayTimeUI();
    }

    private void DisplayTimeUI()
    {
        float currentTime = Time.timeSinceLevelLoad;
        int wholeSeconds = Mathf.FloorToInt(currentTime);
        int decimalSeconds = Mathf.FloorToInt((currentTime - wholeSeconds) * 100);

        timeText.text = $"<size=60>{wholeSeconds}</size><size=30>.{decimalSeconds}</size>";
    }
}

