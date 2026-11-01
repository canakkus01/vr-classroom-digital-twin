using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns grabbable props at a spawn point and removes them again.
/// Called from the World Space UI buttons "Spawn Prop" and "Clear Props".
/// </summary>
public class PropSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] propPrefabs;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnRadius = 0.5f;
    [SerializeField] private int maxSpawnedProps = 15;

    private readonly List<GameObject> spawnedProps = new List<GameObject>();
    private int nextPrefabIndex;

    public void SpawnProp()
    {
        if (propPrefabs == null || propPrefabs.Length == 0 || spawnPoint == null)
        {
            Debug.LogWarning("PropSpawner: assign prop prefabs and a spawn point in the Inspector.");
            return;
        }

        if (spawnedProps.Count >= maxSpawnedProps)
        {
            RemoveOldestProp();
        }

        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
        Vector3 position = spawnPoint.position + new Vector3(randomOffset.x, 0f, randomOffset.y);

        GameObject prefab = propPrefabs[nextPrefabIndex];
        nextPrefabIndex = (nextPrefabIndex + 1) % propPrefabs.Length;

        GameObject newProp = Instantiate(prefab, position, Random.rotation);
        spawnedProps.Add(newProp);
    }

    public void ClearSpawnedProps()
    {
        foreach (GameObject prop in spawnedProps)
        {
            if (prop != null)
            {
                Destroy(prop);
            }
        }
        spawnedProps.Clear();
    }

    private void RemoveOldestProp()
    {
        GameObject oldest = spawnedProps[0];
        spawnedProps.RemoveAt(0);
        if (oldest != null)
        {
            Destroy(oldest);
        }
    }
}
