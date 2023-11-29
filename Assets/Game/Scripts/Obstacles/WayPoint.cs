using System;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform flame;
    [SerializeField] private GameObject[] wayPoints;
    
    
    private int currentWayPointIndex = 0;
    private void Start() => flame.position = wayPoints[currentWayPointIndex].transform.position;

    private void Update()
    {
        if (Vector2.Distance(wayPoints[currentWayPointIndex].transform.position, flame.transform.position) < 0.2f)
        {
            currentWayPointIndex++;
            if (currentWayPointIndex >= wayPoints.Length)
            {
                currentWayPointIndex = 0;
            }
            
        }

        flame.transform.position = Vector2.MoveTowards(flame.transform.position, wayPoints[currentWayPointIndex].transform.position,
            Time.deltaTime * speed);
    }
}
