using System;
using TMPro;
using UnityEngine;


public class DisplayCurrentTime : MonoBehaviour
{ 
    [SerializeField] private VoidEventChannelSO startTheGame;
    [SerializeField] private VoidEventChannelSO playerDeath;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private VoidEventChannelSO levelCompleted;
    [SerializeField] private int wholeSecondSize = 60;
    [SerializeField] private int decimalSecondSize = 30;

    private bool _startCounting;

    private void Awake()
    {
        startTheGame.RegisterListener(StartTheCounting);
        levelCompleted.RegisterListener(DisableCurrentTimeText);
        playerDeath.RegisterListener(StopTheCounting);
    }

    public TextMeshProUGUI GetCurrentTimeText()
    {
        return timeText;
    }

    private void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        timeText.text = FancyTimeFormat("0", "00");
    }

    private void StartTheCounting() => _startCounting = true;
    private void StopTheCounting() => _startCounting = false;
    
    private void Update()
    {
        if(_startCounting) DisplayTimeUI();
    }

    private void DisplayTimeUI()
    {
        float currentTime = Time.timeSinceLevelLoad;
        int wholeSeconds = Mathf.FloorToInt(currentTime);
        int decimalSeconds = Mathf.FloorToInt((currentTime - wholeSeconds) * 100);
        timeText.text = FancyTimeFormat(wholeSeconds.ToString(), decimalSeconds.ToString());
    }

    private void DisableCurrentTimeText()
    {
        gameObject.SetActive(false);
    }

    private string FancyTimeFormat(string wholeSeconds, string decimalSeconds)
    {
        return $"<size={wholeSecondSize.ToString()}>{wholeSeconds}</size><size={decimalSecondSize.ToString()}>.{decimalSeconds}</size>";
    }

    private void OnDisable()
    {
        startTheGame.UnregisterListener(StartTheCounting);
        playerDeath.UnregisterListener(StopTheCounting); 
        levelCompleted.UnregisterListener(DisableCurrentTimeText);   
    }

}

