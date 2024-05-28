using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadeau : MonoBehaviour
{
    public ObjectData objectData;
    public float spawnRadius = 10f; 

    private void Start()
    {
       
        Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
        transform.position = new Vector3(randomPosition.x, randomPosition.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            DestroyPresent();
        }
    }

    private void DestroyPresent()
    {
        
        if (objectData.lootTable.Length > 0)
        {
            int randomIndex = Random.Range(0, objectData.lootTable.Length);
            Instantiate(objectData.lootTable[randomIndex], transform.position, Quaternion.identity);
        }

       
        Destroy(gameObject);
    }
}