using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnnemiePunch : MonoBehaviour
{
    public Player player;
    public UnityEvent comboBreaker;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            player.pvPlayer -= transform.parent.GetComponent<EnnemyMovement>()._damage;
            //pour le combo
            comboBreaker.Invoke();
           
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
