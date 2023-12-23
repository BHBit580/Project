using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip spaceMusic;

    private void Start()
    {
        SoundManager.instance.PlayMusicLoop(spaceMusic);
    }
}
