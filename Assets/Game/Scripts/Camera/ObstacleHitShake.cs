using UnityEngine;
using FirstGearGames.SmoothCameraShaker;


public class ObstacleHitShake : MonoBehaviour
{
    [SerializeField] private ShakeData playerHitShakeData;
    [SerializeField] private VoidEventChannelSO playerDeath;
    
    private void Awake()
    {
        playerDeath.RegisterListener(PlayerHitObstacle);
    }
    
    private void PlayerHitObstacle()
    {
        Debug.Log("IHODAOHWOO");
        CameraShakerHandler.Shake(playerHitShakeData);
    }
    
    private void OnDisable()
    {
        playerDeath.UnregisterListener(PlayerHitObstacle);
    }
}
