using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public Player playerData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 )
        {
            collision.GetComponent<Item>().Damaged();
        }

        if (collision.gameObject.layer == 7)
        {
            collision.GetComponent<EnnemyMovement>().GotDamaged(playerData.dmgPlayer);
        }
    }

    void Start()
    {
       
    }

  
    void Update()
    {

    }

}
