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
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayEffectSoundOneShot(AudioClip clip , float volume = 1f)
    {
        effectSource.volume = volume;
        effectSource.PlayOneShot(clip);
    }

    public void PlayMusicLoop(AudioClip clip, float volume = 1f)
    {
        musicSource.clip = clip;
        musicSource.volume = volume;
        musicSource.Play();
        musicSource.loop = true;
    }

    public void PlayEffectSoundLoop(AudioClip clip, float volume = 1f)
    {
        effectSource.clip = clip;
        effectSource.volume = volume;
        effectSource.Play();
        effectSource.loop = true;
    }
    
    public void FadeOutMusic(float fadeTime)
    {
        StartCoroutine(FadeOut(musicSource, fadeTime));
    }

    private IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
    
    public void FadeInMusic(AudioClip clip , float fadeTime , float volume , bool loopCondition)
    {
        musicSource.clip = clip;
        musicSource.volume = volume; 
        StartCoroutine(FadeIn(musicSource, fadeTime));
        musicSource.loop = true;
    }
    
    private IEnumerator FadeIn(AudioSource audioSource, float fadeTime)
    {
        float startVolume = 0.2f;
 
        audioSource.volume = 0;
        audioSource.Play();
 
        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / fadeTime;
 
            yield return null;
        }
 
        audioSource.volume = 1f;
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