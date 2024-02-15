using FirstGearGames.SmoothCameraShaker;
using UnityEngine;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour {

    [SerializeField] private VoidEventChannelSO playerDeath;
    [SerializeField] private ShakeData myShakeSoData;
    [SerializeField] private float smoothTime = 0.125f;
    [SerializeField] private float groundWallOffset;
    [SerializeField] private float upWallOffset;

    
    private Vector3 _offset = new Vector3(0 , 0 , -10);
    private Vector3 _velocity;
    private float _cameraPosX;
    private Transform target;
    private GameObject upWall;
    private GameObject groundWall;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        groundWall = GameObject.FindGameObjectWithTag("Ground");
        upWall = GameObject.FindGameObjectWithTag("UpWall");
        _cameraPosX = transform.position.x;
        playerDeath.RegisterListener(ShakeCamera);
    }

    void LateUpdate ()
    {
        Vector3 targetPosition = target.position + _offset;

        // Calculate the lower and upper bounds of the camera in world coordinates
        float cameraHeight = 2f * Camera.main.orthographicSize;
        float desiredLowerYPos = groundWall.transform.position.y + groundWallOffset + cameraHeight / 2f;
        float desiredUpperYPos = upWall.transform.position.y - upWallOffset - cameraHeight / 2f;

        // Adjust the minimum and maximum y-position of the camera
        float min = desiredLowerYPos;
        float max = desiredUpperYPos;
        float yPos = Mathf.Clamp(Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime).y, min , max);
    
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