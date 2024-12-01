
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeField] private Item[] itemPrefabs;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Collider spawnCollider;

    private List<Item> spawnItems = new List<Item>();

    private void Start()
    {
        Invoke("SpawnItem", 1.5f);
        Invoke("SpawnEnemy", 10);
    }

    private void FixedUpdate()
    {
        spawnItems.RemoveAll(x => x == null);
    }

    private void SpawnItem()
    {
        Bounds bounds = spawnCollider.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        Item newItem = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)], new Vector3(randomX, randomY, randomZ), Quaternion.identity);
        spawnItems.Add(newItem);
        Invoke("SpawnItem", 1.5f);
    }

    private void SpawnEnemy()
    {
        Bounds bounds = spawnCollider.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        Instantiate(enemyPrefab.gameObject, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
        Invoke("SpawnEnemy", 5f);
    }
}
