using UnityEngine;

public class AdjustUpWall : MonoBehaviour
{
    [SerializeField] private float distanceToPlayer = 20f;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) <= distanceToPlayer)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 50, transform.position.z);
        }
    }
}
