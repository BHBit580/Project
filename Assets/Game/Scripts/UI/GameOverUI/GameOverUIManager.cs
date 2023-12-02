using UnityEngine;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO levelCompleted;

    private bool isDestroyed = false;

    private void Start()
    {
        EnableAllChildrenRecursive(transform, false);
        
        levelCompleted.RegisterListener(() =>
        {
            if (!isDestroyed) EnableAllChildrenRecursive(transform, true);
        });
    }

    private void EnableAllChildrenRecursive(Transform parent, bool value)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            EnableAllChildrenRecursive(child, value);
            if (child.gameObject != null) child.gameObject.SetActive(value);
        }
    }

    private void OnDisable()
    {
        // Unregister the callback function when the script is disabled
        levelCompleted.UnregisterListener(() =>
        {
            if (!isDestroyed) EnableAllChildrenRecursive(transform, true);
        });
    }

    private void OnDestroy()
    {
        // Set the flag to true when the object is being destroyed
        isDestroyed = true;
    }
}