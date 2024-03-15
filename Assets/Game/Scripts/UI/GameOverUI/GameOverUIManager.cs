using System.IO;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO levelCompleted;
    [SerializeField] private GameObject backGround;
    [SerializeField] private float time = 0.5f;
    [SerializeField] private Vector2 finalPosVector;
    private bool isDestroyed = false;
    private void Start()
    {
        EnableAllChildrenRecursive(transform, false);
        backGround.SetActive(false);
        
        levelCompleted.RegisterListener(() =>
        {
            if (!isDestroyed) EnableAllChildrenRecursive(transform, true);
        });
        levelCompleted.RegisterListener(SaveCurrentLevelData);
    }

    private void EnableAllChildrenRecursive(Transform parent, bool value)
    {
        backGround.SetActive(true);
        this.GetComponent<RectTransform>().DOAnchorPos(finalPosVector, time);
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
        levelCompleted.UnregisterListener(SaveCurrentLevelData);
    }

    private void SaveCurrentLevelData()
    {
        GameData gameData = new GameData();
        gameData.lastPlayedLevel = SceneManager.GetActiveScene().buildIndex;

        string dataAsJson = JsonUtility.ToJson(gameData , true);
        
        File.WriteAllText(Application.dataPath + "/LastPlayedLevel.json", dataAsJson);
    }
    
    private void OnDestroy()
    {
        // Set the flag to true when the object is being destroyed
        isDestroyed = true;
    }
}