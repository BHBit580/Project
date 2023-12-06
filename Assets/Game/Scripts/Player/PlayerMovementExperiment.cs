using UnityEngine;

//This is another player movement script with another method to move the player based on input. It's just for experiment purposes.
public class PlayerMovementExperiment : MonoBehaviour
{
    [Header("Forces")]
    [SerializeField] private float upForce = 5f;
    [SerializeField] private float sideForce = 10f;
    
    [Header("MaximumVelocityLimits")]
    [SerializeField] private float maxUpwardVelocity = 5f;
    [SerializeField] private float maxSideWardVelocity = 5f;

    private bool _isPressing;
    private float _previousXInput , _direction;
    
    private Rigidbody2D _playerRigidbody;
    private PlayerInputs _playerInputs;

    private void Awake() => _playerInputs = new PlayerInputs();
    private void OnEnable() => _playerInputs.Enable();
    private void OnDisable() => _playerInputs.Disable();

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        RegisterPlayerInputs();
    }

    private void RegisterPlayerInputs()
    {
        _playerInputs.PlayerActionMap.TouchPress.started += ctx => _isPressing = true;
        _playerInputs.PlayerActionMap.TouchPress.canceled += ctx => _isPressing = false;
    }
    
    private void Update()
    {
        if (_isPressing)
        {
            MovePlayerBasedOnInput();
            ConstrainPlayerVelocity();
        }
    }

    private void MovePlayerBasedOnInput()
    {
        float currentXInput = _playerInputs.PlayerActionMap.TouchPosition.ReadValue<Vector2>().x;                   //Screen Coordinates
        
        if ((int)currentXInput != (int)_previousXInput)
        {
            _direction = Mathf.Sign(currentXInput - _previousXInput);
        }
        else _direction = 0;

            
        float horizontalForce = _direction * sideForce;
            
        _playerRigidbody.AddForce(new Vector2(horizontalForce, upForce) * Time.deltaTime);
        _previousXInput = currentXInput;
    }
    
    private void ConstrainPlayerVelocity()
    {
        float limitedSpeedY = Mathf.Clamp(_playerRigidbody.velocity.y, 0, maxUpwardVelocity);
        float limitedSpeedX = Mathf.Clamp(_playerRigidbody.velocity.x, 0, maxSideWardVelocity); 
        _playerRigidbody.velocity = new Vector2(limitedSpeedX, limitedSpeedY);
    }
}
