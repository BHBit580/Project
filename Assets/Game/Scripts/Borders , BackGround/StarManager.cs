using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    [SerializeField] private GameObject maxLimit, minLimit;
    [SerializeField] private List<GameObject> currentStars;
    [SerializeField] private GameObject starPrefab;

    private void Update()
    {
        for (int i = 0; i < currentStars.Count; i++)
        {
            if (currentStars[i].transform.position.y >= maxLimit.transform.position.y)
            {
                Destroy(currentStars[i]);
                currentStars.Remove(currentStars[i]);

                GameObject ob = SpawnStar();
                ob.transform.SetParent(transform);
                currentStars.Insert(i, ob);
            }
        }
    }

    private GameObject SpawnStar()
    {
        return Instantiate(starPrefab , minLimit.transform.position , Quaternion.identity);
    }
}
