using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public Player player;
    public Transform objectGrabed;
    public LayerMask pickUP;
    public bool itemThrow;
    
    public Vector3 Direction {get;set;}

    public GameObject itemHolding;

    public States currentStates = States.NOHOLDING;
    public enum States
    {
        NOHOLDING,HOLDING,THROW
    }

    
    
       
    private void Update()
    {
        OnStateUpdate();
    }
    public void OnStateEnter()
    {
        switch(currentStates)
        {
            case States.NOHOLDING:
                
                break;
            case States.THROW:
                
                break;
            case States.HOLDING:
                break;
        }
    }
    public void OnStateUpdate()
    {
        switch (currentStates)
        {
            case States.NOHOLDING:
                if (player.isGrabing)
                {
                   TransitionToState(States.HOLDING);
                }

                break;
            case States.THROW:
                
                if (itemHolding != null)
                {
                    itemHolding.transform.position = transform.position + Direction;
                    itemHolding.transform.parent = null;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                    itemHolding = null;
                    itemThrow = false;
                }
                
               
                if (!player.isGrabing)
                {
                    TransitionToState(States.NOHOLDING);
                }


                break;
            case States.HOLDING:
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, 0.4f, pickUP);
                if (pickUpItem)
                {
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = objectGrabed.position;
                    itemHolding.transform.parent = objectGrabed.transform;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                }
                
                if (!player.isGrabing && itemHolding)
                {
                    TransitionToState(States.THROW);
                }
                break;
        }
    }
    public void OnStateExit()
    {
        switch (currentStates)
        {
            case States.NOHOLDING:
                break;
            case States.THROW:
                break;
            case States.HOLDING:
                break;
        }
    }

    public void TransitionToState(States newState)
    {
        OnStateExit();
        currentStates = newState;
        OnStateEnter();
    }
    
    /*IEnumerator ThrowItem(GameObject item)
    {
        Vector3 startPoint = item.transform.position;
        Vector3 endPoint = transform.position + Direction * 2;
        item.transform.parent = null;

        for (int i = 0; i > 25; i++)
        {
            item.transform.position = Vector3.Lerp(startPoint, endPoint, i * 0.04f);
            yield return null;
        }
        if (item.GetComponent<Rigidbody2D>())
            item.GetComponent<Rigidbody2D>().simulated = true;

    }*/
}
