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
    }

    void Start()
    {
       
    }

  
    void Update()
    {

    }

}
