using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnDelay = 5f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<Transform> spawnpoints = new List<Transform>();
    public int count;
    public int level;
    private float nextSpawnTime;

    public void SetLevel() 
    {
        level = count / 20;
        if (level > 5)
        { level = 5; }
        else
        {
            switch (level)
            {
                case 0: spawnDelay = 5f; break;
                case 1: spawnDelay = 4.5f; break;
                case 2: spawnDelay = 4.0f; break;
                case 3: spawnDelay = 3.5f; break;
                case 4: spawnDelay = 3.0f; break;
                case 5: spawnDelay = 2.0f; break;
            }
        }
    }
    void Update()
    {

        if (nextSpawnTime > Time.time) return;

        nextSpawnTime = Time.time + spawnDelay;

        Vector2 spawnPos = spawnpoints[Random.Range(0, spawnpoints.Count - 1)].position;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
