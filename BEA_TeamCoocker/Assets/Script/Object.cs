using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField]
    public ObjectData objectData;
    private int currentUsure;
    private bool isPickable = false;

    private void Start()
    {
        currentUsure = objectData.usure;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            isPickable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            isPickable = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null && isPickable)
        {
           //Player methode pour pickup;
        }
    }


    public void UseObjectToPunch()
    { // Methode a appeler dans player quand il punch l'ennemi
        if (currentUsure > 0)
        {
            currentUsure--;

            if (currentUsure <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

 

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        //if (enemy != null)
        {
            
            //enemy.TakeDamage(objectData.damage);

            UseObjectToPunch();
        }
    }

}