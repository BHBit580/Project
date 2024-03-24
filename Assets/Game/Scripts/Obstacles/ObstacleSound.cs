using UnityEngine;

public class ObstacleSound : MonoBehaviour
{
    [SerializeField] private float maxDistance = 10f; // Maximum distance at which the sound is audible
    [SerializeField] private float maxVolume = 1f; // Maximum volume when the player is at minimum distance
    
    
    private Transform _player; // Reference to the player object
    private AudioSource _fireballAudio; // Reference to the AudioSource attached to the fireball

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _fireballAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_player is not null && _fireballAudio is not null)
        {
            // Calculate the distance between the player and the fireball
            float distance = Vector3.Distance(_player.position, transform.position);

            // Calculate the volume based on the distance
            float volume = Mathf.Lerp(maxVolume, 0, distance / maxDistance);

            // Clamp the volume to ensure it's within the desired range
            volume = Mathf.Clamp(volume, 0, maxVolume);

            // Set the volume of the AudioSource
            _fireballAudio.volume = volume;
        }
    }
}
