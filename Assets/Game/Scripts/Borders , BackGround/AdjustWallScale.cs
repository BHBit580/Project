using UnityEngine;

[ExecuteInEditMode]

public class AdjustWallScale : MonoBehaviour
{
    [SerializeField] private Transform leftBorder , rightBorder;
    [SerializeField] private VoidEventChannelSO collectOrbLevelPopUpUI;
    [SerializeField] private float multiplier = 1f;

    private OrbElement orbElement;
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        orbElement = player.GetComponent<OrbElement>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(leftBorder.position , rightBorder.position);
        transform.localScale = new Vector3(distance , transform.localScale.y , transform.localScale.z) * multiplier;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(this.gameObject.CompareTag("Ground")) return;    // This code present in both ground and upWall
        if (col.gameObject.CompareTag("Player") && orbElement.nofOfOrbs > 0)
        {
            collectOrbLevelPopUpUI.RaiseEvent();
        }
    }
}
