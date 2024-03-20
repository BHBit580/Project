using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Game.Scripts.Player
{ 
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speedMultiplier = 650;
        [SerializeField] private AudioClip tapSound;
        [SerializeField] private float maxVelocity = 5;

        private Rigidbody2D _playerRigidbody;
        private float _upwardForce = 2f;
        private Vector2 _movementVector;
        private bool _isForceApplied;

        private float _screenWidth;
        private Camera _mainCamera;

        private void Start()
        {
            _playerRigidbody = GetComponentInChildren<Rigidbody2D>();
            _mainCamera = Camera.main;
            _screenWidth = Camera.main.aspect * Camera.main.orthographicSize;
        }

        #region PlayerInputs

        private void OnTouchInput(InputValue value)
        {
            if (value.Get<float>() > 0.5f)
            {
                SoundManager.instance.PlayEffectSoundOneShot(tapSound);
                _isForceApplied = true;
            }
        }

        private void OnTouchPosition(InputValue value)
        {
            GetMovementVector(value.Get<Vector2>());
        }

        #endregion

        private void Update()
        {
            ConstrainUpwardVelocity();
            CheckWrapAround();
        }

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
            Vector2 touchKiWorldPosition = _mainCamera.ScreenToWorldPoint(touchPosition);
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

        private void CheckWrapAround()
        {
            Vector3 viewPos = _mainCamera.WorldToViewportPoint(transform.position);
    
            if (viewPos.x < 0 || viewPos.x > 1) // If player is out of the camera's viewport horizontally
            {
                // Determine the direction of crossing
                float screenWidth = _mainCamera.aspect * _mainCamera.orthographicSize;
                bool crossedLeftBoundary = viewPos.x < 0;
        
                // Calculate new position on the opposite side
                float newX = crossedLeftBoundary ? screenWidth : -screenWidth;
                
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
        }
    }
}
