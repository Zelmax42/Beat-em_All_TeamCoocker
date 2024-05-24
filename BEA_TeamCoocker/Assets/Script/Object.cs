using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    
    public ObjectData objectData;
    private int currentUsure;
    private bool isPickable = false;

    private void Start()
    {
        currentUsure = objectData.usure;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = GetComponent<Player>();
        if (player != null)
        {
            isPickable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Player player = GetComponent<Player>();
        if (player != null)
        {
            isPickable = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Player player = GetComponent<Player>();
        if (player != null && isPickable)
        {
            HandleObjectPickup(player);
        }
    }

    private void HandleObjectPickup(Player player)
    {
      
        if (isPickable && currentUsure > 0)
        {

            //Appel du punch du player
            
            if (currentUsure <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

