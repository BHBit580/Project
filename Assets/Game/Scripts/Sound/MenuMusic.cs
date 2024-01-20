using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    [SerializeField] private AudioClip startingAudioClip;
    [SerializeField] private float fadeTime = 1f;
    [SerializeField] private float volume = 1f;
    void Start()
    {
        SoundManager.instance.PlayMusicLoop(startingAudioClip , volume);
    }
}
