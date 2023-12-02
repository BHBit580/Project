using UnityEngine;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO levelCompleted;

    private void Start()
    {
        EnableAllChildrenRecursive(transform, false);
        levelCompleted.RegisterListener(DisablePlayer);
        levelCompleted.RegisterListener(() => EnableAllChildrenRecursive(transform, true));
    }

    private void EnableAllChildrenRecursive(Transform parent, bool value)
    {
        foreach (Transform child in parent)
        {
            EnableAllChildrenRecursive(child, value);
            if(child.gameObject!=null) child.gameObject.SetActive(value);
        }
    }

    private void DisablePlayer()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
    }

    private void OnDisable()
    {
        levelCompleted.UnregisterListener(DisablePlayer);
        levelCompleted.UnregisterListener(() => EnableAllChildrenRecursive(transform, true));
    }
}