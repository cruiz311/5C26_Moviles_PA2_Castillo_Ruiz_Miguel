using System.Collections.Generic;
using UnityEngine;

public class FruitPool:MonoBehaviour
{
    public GameObject[] fruitPrefabs; 
    public int poolSize = 3; 

    private static List<GameObject> fruitPool; 

    private void Awake()
    {
        fruitPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {

            GameObject enemy = Instantiate(fruitPrefabs[Random.Range(0, fruitPrefabs.Length)]);
            enemy.SetActive(false);
            fruitPool.Add(enemy);
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
