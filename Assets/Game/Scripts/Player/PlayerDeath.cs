using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO playerDeath;
    [SerializeField] private VoidEventChannelSO levelCompleted;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private AudioClip[] deathSound;

    private void Start()
    {
        levelCompleted.RegisterListener(DisablePlayer);
    }
    
    private void PlayerDie()
    {
        PlayDeathParticles();
        DisablePlayer();
    }

    private void ReLoadCurrentScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private void PlayDeathParticles()
    {
        Instantiate(particleSystem, transform.position, Quaternion.identity);
        particleSystem.Play();
        Invoke(nameof(ReLoadCurrentScene), 3f);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            playerDeath.RaiseEvent();
            PlayerDie();
            PlayDeathMultipleSounds();
        }
    }

    private void PlayDeathMultipleSounds()
    {
        foreach (var sound in deathSound)
        {
            SoundManager.instance.PlayEffectSoundOneShot(sound);
        }
    }

    private void DisablePlayer()
    {
        gameObject.SetActive(false);
    }
    
    private void OnDisable()
    {
        levelCompleted.UnregisterListener(DisablePlayer);
    }
    
}
