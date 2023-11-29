using System;
using System.Collections.Generic;
using FirstGearGames.SmoothCameraShaker;
using UnityEngine;

public class MegaExplosion : MonoBehaviour
{
    [SerializeField] private ShakeData explosionShakeData;
    [SerializeField] private VoidEventChannelSO playerDeath;
    [SerializeField] private float distanceToStartTrigger = 20f;
    [SerializeField] private float explosionRadius = 2.4f;
    [SerializeField] private float timeToExplode = 1.75f;
    
    private ParticleSystem _particleSystem;
    private Transform _playerTransform;
    
    private bool _isPlaying;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (!_isPlaying && (transform.position - _playerTransform.position).magnitude <= distanceToStartTrigger)
        {
            _particleSystem.Play();
            Invoke(nameof(PlayerShouldDie), timeToExplode);
            if (_particleSystem.isPlaying) 
            {
                CameraShakerHandler.Shake(explosionShakeData);
                _isPlaying = true;
            }
        }
        
        if (_isPlaying && _particleSystem.isStopped)
        {
            Debug.Log("Stopped");
            _isPlaying = false;
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,explosionRadius);
    }

    private void PlayerShouldDie()
    {
        if ((_playerTransform.position - transform.position).magnitude > explosionRadius) return;
        playerDeath.RaiseEvent();
    }
}
