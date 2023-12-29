using System;
using UnityEngine;

public class UpWall : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO allOrbsCollected;
    [SerializeField] private VoidEventChannelSO levelCompleted;
    [SerializeField] private float uiDisplayDelay = 1f;
    [SerializeField] private GameObject upWall;
    [SerializeField] private GameObject newUpWallWithSpace;
    [SerializeField] private GameObject lastLineExplosion;
    [SerializeField] private float fadeBackgroundMusicTime = 0.5f;
    [SerializeField] private AudioClip[] levelCompletedSound;

    private void Start()
    {
        allOrbsCollected.RegisterListener(DisplayNewUpWall);
        lastLineExplosion.SetActive(false);
        newUpWallWithSpace.SetActive(false);
        upWall.SetActive(true);
    }

    private void DisplayNewUpWall()
    {
        foreach (var sound in levelCompletedSound)
        {
            SoundManager.instance.PlayEffectSoundOneShot(sound);
        }
        upWall.SetActive(false);
        lastLineExplosion.SetActive(true);
        newUpWallWithSpace.SetActive(true);
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
            SoundManager.instance.FadeOutMusic(fadeBackgroundMusicTime);
            Invoke(nameof(InvokeLevelCompletedUI), uiDisplayDelay);
            Debug.Log("LevelCompleted");
        }
    }
}
