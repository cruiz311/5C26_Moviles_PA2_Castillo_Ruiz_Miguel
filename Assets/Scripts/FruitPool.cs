using System.Collections.Generic;
using UnityEngine;

public class FruitPool:MonoBehaviour
{
    public List<FrutaSO> frutaDataList;
    public int poolSize = 3; 

    private static List<GameObject> fruitPool;

    private void Awake()
    {
        fruitPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            FrutaSO randomFruitData = frutaDataList[Random.Range(0, frutaDataList.Count)];
            GameObject fruitPrefab = randomFruitData.fruitPrefab;
            GameObject fruit = Instantiate(fruitPrefab);
            fruit.SetActive(false);
            fruitPool.Add(fruit);
        }
    }


    public static GameObject GetFruit()
    {
        foreach (GameObject fruit in fruitPool)
        {
            if (!fruit.activeInHierarchy)
            {
                fruit.SetActive(true);
                return fruit;
            }
        }

        return null;
    }

    public static void ReturnFruitToPool(GameObject fruit)
    {
        fruit.SetActive(false);
    }
}
