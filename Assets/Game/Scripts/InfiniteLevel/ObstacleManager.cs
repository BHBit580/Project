using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GameObject normalObstaclePrefab;
    
    private List<GameObject> _obstaclesInTheScene = new();
    private Camera _mainCamera;
    private float _minX, _maxX;

    private void Start()
    {
        _mainCamera = Camera.main;
        FindScreenWidth();
    }

    private void Update()
    {
        
    }

    private void SpawnNormalObstacle()
    {
        
    }
    
    private void FindScreenWidth()
    {
        float screenWidth = _mainCamera.aspect * _mainCamera.orthographicSize;
        _minX = -screenWidth;
        _maxX = screenWidth;
    }
    
    private void DisableObstacles()
    {
        
    }
}
