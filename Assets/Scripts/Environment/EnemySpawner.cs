using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnDelay = 5f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<Transform> spawnpoints = new List<Transform>();

    private float nextSpawnTime;

    void Update()
    {
        if (nextSpawnTime > Time.time) return;

        nextSpawnTime = Time.time + spawnDelay;

        Vector2 spawnPos = spawnpoints[Random.Range(0, spawnpoints.Count - 1)].position;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
