using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsUp : MonoBehaviour
{
    [SerializeField] private float speed = 0.05f;
    void Update()
    {
        transform.Translate(Vector3.up * (speed * Time.deltaTime));
    }
}
