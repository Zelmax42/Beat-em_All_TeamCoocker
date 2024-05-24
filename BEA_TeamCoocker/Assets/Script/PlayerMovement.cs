using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D _rb2d;
    public SpriteRenderer image;
    public Animator animator;

    [Header("Speed")]
    public float moveSpeed = 5f;
    public float playerMovement = 0f;

    private Vector2 _direction;

    [Header("Jump")]
    public float jumpForce = 5f;
    private bool _isJumped = false;
    

    [Header("Ground Detection")]
    public LayerMask groundLayer;
    public Vector2 groundCheckerSize = Vector2.one;
    public Transform groundCheckerTransform;
    private bool _isGrounded = false;

    [Header("Punch")]
    public bool punchFinish = false;
    private bool _isPunched = false;
    public GameObject punch;

    public States currentStates = States.Ilde;
    public enum States
    {
        Ilde, Walk, Punch, Jump , Grab , Hurt, Fall, Ultimate , Dead
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnStateUpdate();
        Collider2D ground = Physics2D.OverlapBox(groundCheckerTransform.position, groundCheckerSize, 0f, groundLayer);
        
        if (ground != null)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }

    }

    private void OnDrawGizmos()
    {
        if (_isGrounded)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }

        Gizmos.DrawCube(groundCheckerTransform.position, groundCheckerSize);
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
                punch.SetActive(true);
                moveSpeed = 0f;
                break;
            case States.Jump:
                _rb2d.gravityScale = 1f;
                _isJumped = false;
                _rb2d.velocity = new Vector2(transform.localPosition.x, jumpForce);
                break;
            case States.Hurt:   
                break;
            case States.Fall:
                _rb2d.gravityScale = 2f;
                break;
            case States.Ultimate:
                break;
            case States .Dead:
                break;

        }
    }
    
    public void OnStateUpdate()
    {
        switch (currentStates)
        {
            case States.Ilde:
                if(_direction.magnitude > 0f)
                { 
                    TransitionToState(States.Walk);
                }
                if (_isJumped && _isGrounded)
                {
                    TransitionToState(States.Jump);
                }
                if (_isPunched)
                {
                    TransitionToState(States.Punch);
                }
                break;
            case States.Walk: 
                transform.parent.Translate( moveSpeed * _direction * Time.deltaTime);
                if ( _direction.magnitude == 0f )
                {
                    TransitionToState(States.Ilde);
                }
                if (_isJumped && _isGrounded )
                {
                    TransitionToState(States.Jump);
                }
                if (_isPunched)
                {
                    TransitionToState(States.Punch);
                }
                break;
                
            case States.Jump:
                
                transform.parent.Translate(moveSpeed * _direction * Time.deltaTime);
                
                    if (_rb2d.velocity.y < 0f)
                    {
                        TransitionToState(States.Fall);
                    }
                
                break;
                
            case States.Fall:
                
                transform.parent.Translate(moveSpeed * _direction * Time.deltaTime);

                if (_isGrounded)
                {
                    if (_direction.magnitude == 0f)
                    {
                        TransitionToState(States.Ilde);
                    }
                    else if (_direction.magnitude > 0f)
                    {
                        TransitionToState(States.Walk);
                    }
                }
                break;

            case States.Punch:
                transform.parent.Translate(moveSpeed * _direction * Time.deltaTime);
                

                if (punchFinish)
                {
                    if (_direction.magnitude == 0f)
                    {
                        TransitionToState(States.Ilde);
                    }
                    if (_direction.magnitude > 0f)
                    {
                        TransitionToState(States.Walk);
                    }
                }
                    break;   
            case States.Hurt:
                break;
            case States.Ultimate:
                break;
            case States.Dead:
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
                moveSpeed = 5f;
                punch.SetActive(false);
                break;
            case States.Jump:
                break;
            case States.Hurt:
                break;
            case States.Fall:
                _rb2d.gravityScale = 0f;
                break;
            case States.Ultimate:
                break;
            case States.Dead:
                break;
        }
    }

    public void TransitionToState(States newState)
    {
        OnStateExit();
        currentStates = newState;
        OnStateEnter();
    }

    public void Move(InputAction.CallbackContext context )
    {
        switch(context.phase)
        {
            case InputActionPhase.Performed:                    
                _direction =  context.ReadValue<Vector2>();
                break;
            case InputActionPhase.Canceled:
                _direction = Vector2.zero;
                break;
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                _isJumped = true;
                break;
            case InputActionPhase.Canceled:
                _isJumped = false;
                break;             
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                _isPunched = true;

                break;
            case InputActionPhase.Canceled:
                _isPunched = false;
                break;
        }
    }
    public void Ultimat(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:

                break;
            case InputActionPhase.Canceled:

                break;
        }
    }
    public void Grab(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:

                break;
            case InputActionPhase.Canceled:

                break;
        }
    }
}
