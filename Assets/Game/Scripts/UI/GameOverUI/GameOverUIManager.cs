using UnityEngine;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO levelCompleted;

    private void Start()
    {
        EnableAllChildren(false);
        levelCompleted.RegisterListener(DisablePlayer);
        levelCompleted.RegisterListener(() => EnableAllChildren(true));
    }

    private void EnableAllChildren(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }
    
    private void DisablePlayer()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
    }
    
    private void OnDisable()
    {
        levelCompleted.UnregisterListener(DisablePlayer);
        levelCompleted.UnregisterListener(() => EnableAllChildren(true));
    }
    
    
}
