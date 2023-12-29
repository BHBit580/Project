using UnityEngine;
using UnityEngine.Serialization;

public class StartPlayer : MonoBehaviour
{
    [SerializeField] private GameObject particleSystem;
    [SerializeField] private GameObject collider;
    [SerializeField] private VoidEventChannelSO startTheGame;

    private PlayerInputs _playerInputs;

    private void Awake() => _playerInputs = new PlayerInputs();
    private void OnEnable() => _playerInputs.Enable();
    private void OnDisable() => _playerInputs.Disable();

    private void Start()
    {
        RegisterPlayerInputs();
    }

    private void RegisterPlayerInputs()
    {
        _playerInputs.PlayerActionMap.TouchPress.started += ctx => StartTheGame();
    }
    
    private void StartTheGame()
    {
        particleSystem.SetActive(false);
        collider.SetActive(false);
        startTheGame.RaiseEvent();
        gameObject.SetActive(false);
    }
}
