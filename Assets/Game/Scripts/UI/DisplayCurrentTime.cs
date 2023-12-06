using System;
using TMPro;
using UnityEngine;


public class DisplayCurrentTime : MonoBehaviour
{ 
    [SerializeField] private VoidEventChannelSO startTheGame;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private VoidEventChannelSO levelCompleted;
    [SerializeField] private int wholeSecondSize = 60;
    [SerializeField] private int decimalSecondSize = 30;

    private bool _startCounting;

    private void Awake()
    {
        startTheGame.RegisterListener(StartTheCounting);
        levelCompleted.RegisterListener(DisableCurrentTimeText);
    }

    public TextMeshProUGUI GetCurrentTimeText()
    {
        return timeText;
    }

    private void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        timeText.text = null;
    }

    private void StartTheCounting() => _startCounting = true;
    
    private void Update()
    {
        if(_startCounting) DisplayTimeUI();
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

    private void OnDisable()
    {
        startTheGame.UnregisterListener(StartTheCounting);
        levelCompleted.UnregisterListener(DisableCurrentTimeText);   
    }

}

