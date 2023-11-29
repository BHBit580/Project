using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO playerDeath;
    [SerializeField] private ParticleSystem particleSystem;

    private void Start()
    {
        playerDeath.RegisterListener(PlayerDie);
    }
    
    private void PlayerDie()
    {
        HidePlayerVisuals();
        PlayDeathParticles();
    }

    private void ReLoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void HidePlayerVisuals()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    private void PlayDeathParticles()
    {
        DestroyChildren();
        Instantiate(particleSystem, transform.position, Quaternion.identity);
        particleSystem.Play();
        Invoke(nameof(ReLoadCurrentScene), 3f);
    }

    private void DestroyChildren()
    {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }
    
    private void OnDisable()
    {
        playerDeath.UnregisterListener(PlayerDie);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            PlayerDie();
        }
    }
}
