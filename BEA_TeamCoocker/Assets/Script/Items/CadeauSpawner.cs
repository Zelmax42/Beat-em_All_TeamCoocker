using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CadeauSpawner : MonoBehaviour
{
    public GameObject cadeauPrefab;
    public float spawnInterval = 5f; 
    public float spawnRadius = 10f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCadeau), 5f, spawnInterval);
    }

    private void SpawnCadeau()
    {
        Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
        Instantiate(cadeauPrefab, new Vector3(randomPosition.x, randomPosition.y, 0f), Quaternion.identity);
    }
}