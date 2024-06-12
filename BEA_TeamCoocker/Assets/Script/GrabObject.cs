using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    private Animator _animatorPlayer;

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
        _animatorPlayer = GetComponentInChildren<Animator>();
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

                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, 0.4f, pickUP);
                if(pickUpItem)
                {
                    pickUpItem.GetComponentInChildren<TextGrab>(true).gameObject.SetActive(true);
                    pickUpItem.GetComponentInChildren<TextGrab>(true).ResetGrabText();

                }
                if (player.isGrabing)
                {
                   
                    if (pickUpItem)
                    {
                        _animatorPlayer.SetBool("isGrabing",true);
                        itemHolding = pickUpItem.gameObject;
                        itemHolding.GetComponent<Item>().isPickUp = true;
                        itemHolding.GetComponent<ObjectThrow>().Grabed();
                        itemHolding.transform.position = objectGrabed.position;
                        itemHolding.transform.parent = objectGrabed.transform;
                        itemHolding.transform.localEulerAngles = objectGrabed.localEulerAngles;
                        itemHolding.GetComponent<ObjectThrow>().objectThrow = true;
                        if (itemHolding.GetComponent<Rigidbody2D>())
                            itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                        TransitionToState(States.HOLDING);
                    }
                   
                }

                break;
            case States.THROW: 

                if (itemHolding != null)
                {
                    _animatorPlayer.SetBool("isGrabing",false);
                    itemHolding.transform.parent = null;
                    itemHolding.GetComponent<Item>().isPickUp = false;
                    itemHolding.GetComponent<ObjectThrow>().ThrowObject();
                    itemHolding.GetComponent<ObjectThrow>().objectThrow = false;
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

    /*public void OnDrawGizmos()
    {
        Gizmos.DrawSphere
    }*/
}

