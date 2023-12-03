using System;
using TMPro;
using UnityEngine;

public class DisplayCurrentTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private VoidEventChannelSO levelCompleted;
    [SerializeField] private int wholeSecondSize = 60;
    [SerializeField] private int decimalSecondSize = 30;

    private void Awake() => levelCompleted.RegisterListener(DisableCurrentTimeText);

    public TextMeshProUGUI GetCurrentTimeText()
    {
        return timeText;
    }

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

        timeText.text = $"<size={wholeSecondSize.ToString()}>{wholeSeconds}</size><size={decimalSecondSize.ToString()}>.{decimalSeconds}</size>";
    }

    private void DisableCurrentTimeText()
    {
        gameObject.SetActive(false);
    }
    
    private void OnDisable() => levelCompleted.UnregisterListener(DisableCurrentTimeText);
    
}

