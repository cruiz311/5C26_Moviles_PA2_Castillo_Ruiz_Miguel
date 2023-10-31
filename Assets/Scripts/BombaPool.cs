using System.Collections.Generic;
using UnityEngine;

public class BombaPool:MonoBehaviour
{
    public GameObject bombaPrefab; 
    public int poolSize = 10; 

    private static List<GameObject> bombaPool; 

    private void Awake()
    {
        bombaPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bomba = Instantiate(bombaPrefab);


            bomba.SetActive(false);


            bombaPool.Add(bomba);
        }
    }

    public static GameObject GetBomba()
    {
        foreach (GameObject bomba in bombaPool)
        {
            if (!bomba.activeInHierarchy)
            {
                bomba.SetActive(true);
                return bomba;
            }
        }

        return null;
    }

    public static void ReturnEnemyToPool(GameObject bomba)
    {
        bomba.SetActive(false);
    }
}
