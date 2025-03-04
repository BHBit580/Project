using System;
using UnityEngine;

public class PlayMusicLevelStart : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO startTheGame;
    [SerializeField] private AudioClip spaceMusic;
    [SerializeField] private float timeFadeIn = 0.5f;
    [SerializeField] private float volume = 0.8f;


    private void Start()
    {
        SoundManager.instance.FadeInMusic(spaceMusic, timeFadeIn, volume ,true);
    }
}
