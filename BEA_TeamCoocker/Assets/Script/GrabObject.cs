using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public ObjectData objectData;
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

    public void Start()
    {
        
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
                    itemHolding.transform.parent = null;
                    itemHolding.GetComponent<ObjectThrow>().ThrowObject();
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
                    itemHolding.transform.localEulerAngles = objectGrabed.localEulerAngles;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                }
                
                if (!player.isGrabing)
                {
                    TransitionToState(States.THROW);
                }

                if (!player.isGrabing && !itemHolding)
                {
                    TransitionToState(States.NOHOLDING);
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
    
    IEnumerator ThrowItem(GameObject item)
    {
        
        Vector3 startPosition = item.transform.position;
       
        float timer = objectData.travelDuration;
        float chrono = 0f;

        int step = 25;
        float intervalMeter = objectData.throwDistance / step;
        float intervalTime = 1f / step;


        while (chrono / timer < 1f)
        {
           
            Vector2 curve = new Vector2(chrono / timer * objectData.throwDistance * item.transform.right.x, objectData.myCurve.Evaluate(chrono / timer));
            Debug.Log(curve);
            item.transform.position = startPosition + (Vector3)curve;
            yield return new WaitForEndOfFrame();          
            chrono += Time.deltaTime;
        }
        itemHolding = null;
        StopCoroutine(ThrowItem(item));
    }
}

