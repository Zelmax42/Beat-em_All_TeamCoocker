using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Punch : MonoBehaviour
{
    public Player playerData;
    public UnityEvent comboScore = new UnityEvent();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 )
        {
            collision.GetComponent<Item>().Damaged();
        }

        if (collision.gameObject.layer == 7)
        {
            collision.GetComponent<EnnemyMovement>().GotDamaged(playerData.dmgPlayer);
            comboScore.Invoke();
        }
    }

    void Start()
    {
       
    }

  
    void Update()
    {

    }

}
