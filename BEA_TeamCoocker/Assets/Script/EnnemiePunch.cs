using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiePunch : MonoBehaviour
{
    public Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            player.pvPlayer -= transform.parent.GetComponent<EnnemyMovement>()._damage;
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
