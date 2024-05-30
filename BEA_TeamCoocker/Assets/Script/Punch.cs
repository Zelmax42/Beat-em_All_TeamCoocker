using System;
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
            Debug.Log("je touche");
            try
            {
               collision.GetComponent<EnnemyMovement>().GotDamaged(playerData.dmgPlayer);
            }
            catch(SystemException) { }
            try
            {
                collision.GetComponent<BossV1>().GotDamaged(playerData.dmgPlayer);
            }
            catch (SystemException) { }
        }
    }

    void Start()
    {
       
    }

  
    void Update()
    {

    }

}
