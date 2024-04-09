using System;
using System.Collections;
using UnityEngine;

public class UpWall : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO allOrbsCollected;
    [SerializeField] private VoidEventChannelSO levelCompleted;
    [SerializeField] private float uiDisplayDelay = 1f;
    [SerializeField] private GameObject upWall;
    [SerializeField] private GameObject levelCompleteUpWall;
    [SerializeField] private GameObject lastLineExplosion;
    [SerializeField] private AudioClip[] levelCompletedSound;

    private void Start()
    {
        levelCompleteUpWall.SetActive(false);
        allOrbsCollected.RegisterListener(DisplayNewUpWall);
        lastLineExplosion.SetActive(false);
        upWall.SetActive(true);
    }

    private void DisplayNewUpWall()
    {
        levelCompleteUpWall.SetActive(true);
        foreach (var sound in levelCompletedSound)
        {
            SoundManager.instance.PlayEffectSoundOneShot(sound);
        }
        upWall.SetActive(false);
        lastLineExplosion.SetActive(true);
    } 

    private void OnDisable()
    {
        allOrbsCollected.UnregisterListener(DisplayNewUpWall);
    }
    
    private void InvokeLevelCompletedUI()
    {
        levelCompleted.RaiseEvent();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(InvokeLevelCompletedUI), uiDisplayDelay);
        }
    }
}
