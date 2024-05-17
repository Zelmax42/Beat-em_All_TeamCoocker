using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D _rb2d;
    public SpriteRenderer image;

    public Animator animator;
    public States currentStates = States.Ilde;
    public enum States
    {
        Ilde, Walk, Punch, Jump , Item,
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnStateEnter()
    {
        switch(currentStates) 
        {
            case States.Ilde:
                break;
            case States.Walk:
                break;
            case States.Punch:
                break;
            case States.Jump:
                break;
            case States.Item:   
                break;
        }
    }
    
    public void OnStateUpdate()
    {
        switch (currentStates)
        {
            case States.Ilde:
                break;
            case States.Walk:
                break;
            case States.Punch:
                break;
            case States.Jump:
                break;
            case States.Item:
                break;
        }
    }

    public void OnStateExit()
    {
        switch (currentStates)
        {
            case States.Ilde:
                break;
            case States.Walk:
                break;
            case States.Punch:
                break;
            case States.Jump:
                break;
            case States.Item:
                break;
        }
    }

    public void TransitionToState(States newState)
    {
        OnStateExit();
        currentStates = newState;
        OnStateEnter();
    }
}
