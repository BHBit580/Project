using UnityEngine;

public class UpWallCollisionDetector : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO collectOrbLevelPopUpUI;

    private OrbElement orbElement;
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        orbElement = player.GetComponent<OrbElement>();
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && orbElement.nofOfOrbs > 0)
        {
            collectOrbLevelPopUpUI.RaiseEvent();
        }
    }
}
