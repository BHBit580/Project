using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource musicSource , effectSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayEffectSoundOneShot(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void PlayMusicLoop(AudioClip clip, float volume = 1f)
    {
        musicSource.clip = clip;
        musicSource.Play();
        musicSource.loop = true;
    }

    public void PlayEffectSoundLoop(AudioClip clip, float volume = 1f)
    {
        effectSource.clip = clip;
        effectSource.Play();
        effectSource.loop = true;
    }
    
    public void StopMusic()
    {
        musicSource.Stop();
        musicSource.loop = false;
    }

    public void StopEffect()
    {
        effectSource.Stop();
        effectSource.loop = false;
    }
}