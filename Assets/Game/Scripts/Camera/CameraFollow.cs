using System;
using FirstGearGames.SmoothCameraShaker;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private VoidEventChannelSO playerDeath;
    [SerializeField] private ShakeData myShakeSoData;
    [SerializeField] private Transform target;
    
    [SerializeField] private float smoothTime = 0.125f;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    
    private Vector3 _offset = new Vector3(0 , 0 , -10);
    private Vector3 _velocity;
    private float _cameraPosX;
    private void Start()
    {
        _cameraPosX = transform.position.x;
        playerDeath.RegisterListener(ShakeCamera);
    }

    void LateUpdate ()
    {
        Vector3 targetPosition = target.position + _offset;
        
        float yPos = Mathf.Clamp(Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime).y, minY, maxY);
        
        transform.position = new Vector3(_cameraPosX, yPos , transform.position.z);
    }

    private void ShakeCamera()
    {
        CameraShakerHandler.Shake(myShakeSoData);
    }

    private void OnDisable()
    {
        playerDeath.UnregisterListener(ShakeCamera);
    }
}