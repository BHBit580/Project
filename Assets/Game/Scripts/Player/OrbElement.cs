using System;
using UnityEngine;

public class OrbElement : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystemPrefab;
    [SerializeField] private VoidEventChannelSO allOrbsCollected;

    private GameObject[] _orbs;
    public int nofOfOrbs;
    
    private void Start()
    {
        _orbs = GameObject.FindGameObjectsWithTag("Orb");
        nofOfOrbs = _orbs.Length;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Orb"))
        {
            PlayParticleEffectWhenHit(col);
            OrbsDecreaseLogic();
        }
    }

    private void OrbsDecreaseLogic()
    {
        nofOfOrbs--;
        if (nofOfOrbs == 0)
        {
            Debug.Log("All orbs collected");
            allOrbsCollected.RaiseEvent();
        }
    }

    private void PlayParticleEffectWhenHit(Collider2D col)
    {
        ParticleSystem instantiatedParticleSystem = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);
        Destroy(col.gameObject);
        instantiatedParticleSystem.Play();
        Destroy(instantiatedParticleSystem.gameObject, instantiatedParticleSystem.main.duration);
    }
}
