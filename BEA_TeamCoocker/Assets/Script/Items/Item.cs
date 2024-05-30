using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ObjectData objectData;
    public float spawnRadius = 10f;
    public float currentUsure;
    public bool isThrow;

    private void Start()
    {
        isThrow = false;
        currentUsure = objectData.usure;

        //Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
        //transform.position = new Vector3(randomPosition.x, randomPosition.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.gameObject.layer == 7 && isThrow)
        {
            Debug.Log("touché");
            collision.gameObject.GetComponent<EnnemyMovement>().GotDamaged(objectData.damage);
            Damaged();
            GetComponent<ObjectThrow>().Bonked();
           
        }

    }

    public void Drop() 
    { 
        if (objectData.lootTable.Length > 0 ) 
        {                   
            int randomIndex = Random.Range(0, objectData.lootTable.Length);
            Instantiate(objectData.lootTable[randomIndex], transform.position, Quaternion.identity);    
        }
    }

    public void Damaged() 
    { 
        if(currentUsure == objectData.usure) 
        { 
            Drop();
        }
        currentUsure--;

        if(currentUsure <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}