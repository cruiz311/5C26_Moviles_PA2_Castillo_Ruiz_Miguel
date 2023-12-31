using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider spawnArea;
    [Range(0f, 1f)] public float bombChance = 0.05f;
    public float minSpawnDelay = 0.25f;
    public float maxSpawnDelay = 1f;
    public float minAngle = -15f;
    public float maxAngle = 15f;
    public float minForce = 18f;
    public float maxForce = 22f;
    public float maxLifetime = 5f;

    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        while (enabled)
        {
            Vector3 position = new Vector3();
            position.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            position.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            position.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));

            if (Random.value < bombChance)
            {
                GameObject prefab = BombaPool.GetBomba();
                prefab.transform.position = position;
                prefab.transform.rotation = rotation;
                float force = Random.Range(minForce, maxForce);
                prefab.GetComponent<Rigidbody>().AddForce(prefab.transform.up * force, ForceMode.Impulse);

                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            }
            else
            {
                GameObject prefab = FruitPool.GetFruit();
                prefab.transform.position = position;
                prefab.transform.rotation = rotation;
                float force = Random.Range(minForce, maxForce);
                prefab.GetComponent<Rigidbody>().AddForce(prefab.transform.up * force, ForceMode.Impulse);

                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            }
        }
    }
}
