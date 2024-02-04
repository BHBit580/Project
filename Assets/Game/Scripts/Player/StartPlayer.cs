using UnityEngine;

public class StartPlayer : MonoBehaviour
{
    [SerializeField] private GameObject particleSystem;
    [SerializeField] private VoidEventChannelSO startTheGame;

    private PlayerInputs _playerInputs;

    private void Awake() => _playerInputs = new PlayerInputs();
    private void OnEnable() => _playerInputs.Enable();
    private void OnDisable() => _playerInputs.Disable();

    private Rigidbody2D playerRigidbody2D;
    private void Start()
    {
        RegisterPlayerInputs();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerRigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    private void RegisterPlayerInputs()
    {
        _playerInputs.PlayerActionMap.TouchPress.started += ctx => StartTheGame();
    }
    
    private void StartTheGame()
    {
        playerRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        particleSystem.SetActive(false);
        startTheGame.RaiseEvent();
        gameObject.GetComponent<StartPlayer>().enabled = false;
    }
}
