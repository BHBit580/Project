using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 650;
    [SerializeField] private float maxVelocity = 5;

    private Rigidbody2D _playerRigidbody;
    
    private float _upwardForce = 2f;
    private Vector2 _movementVector;
    private bool _isForceApplied;

    private void Start()
    {
        _playerRigidbody = GetComponentInChildren<Rigidbody2D>();
    }

    #region PlayerInputs
    private void OnTouchInput(InputValue value)
    {
        if (value.Get<float>()>0.5f)
        {
            _isForceApplied = true;
        }
    }

    private void OnTouchPosition(InputValue value)
    {
        GetMovementVector(value.Get<Vector2>());
    }
    #endregion

    private void Update() => ConstrainUpwardVelocity();

    private void FixedUpdate()
    {
        if (_isForceApplied)
        {
            _playerRigidbody.velocity = _movementVector * (speedMultiplier * Time.fixedDeltaTime);
            _isForceApplied = false;
        }
    }

    private void GetMovementVector(Vector2 touchPosition)
    {
        Vector2 touchKiWorldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        _movementVector = new Vector2(touchKiWorldPosition.x - _playerRigidbody.position.x, _upwardForce);
        _movementVector.Normalize();
    }

    private void ConstrainUpwardVelocity()
    {
        if (_playerRigidbody.velocity.y > 0)
        {
            float limitedSpeed = Mathf.Clamp(_playerRigidbody.velocity.magnitude, 0f, maxVelocity);
            _playerRigidbody.velocity = _playerRigidbody.velocity.normalized * limitedSpeed;
        }
    }
    
}








