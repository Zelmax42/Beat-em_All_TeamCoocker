using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Player player;
    public GrabObject GrabObject;
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
    
    

    [Header("Punch")]
    public bool punchFinish = false;
    private bool _isPunched = false;
    public GameObject punch;
   
    void Start()
    {
        GrabObject = gameObject.GetComponent<GrabObject>();
        GrabObject.Direction = _direction;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_direction.magnitude > 0f || _direction.magnitude == 0f)
        {
            GrabObject.Direction = _direction.normalized;
        }

        OnStateUpdate();

        //Detection de sol 
        Collider2D ground = Physics2D.OverlapBox(groundCheckerTransform.position, groundCheckerSize, 0f, groundLayer);
        
        if (ground != null)
        {
            player.isGrounded = true;
        }
        else
        {
           player.isGrounded = false;
        }

    }

    private void OnDrawGizmos()
    {
        //Dectection du sol dessiné
        if (player.isGrounded)
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
        switch(player.currentStates) 
        {
            case Player.States.IDLE:
                break;
            case Player.States.WALK:  
                break;
            case Player.States.PUNCH:
                //animator.Setbool(false)
                moveSpeed = 0f;
                break;
            case Player.States.JUMP:
                _rb2d.gravityScale = 1f;
                _isJumped = false;
                _rb2d.velocity = new Vector2(transform.localPosition.x, jumpForce);
                break;
            case Player.States.HURT:
                break;
            case Player.States.FALL:
                _rb2d.gravityScale = 2f;
                break;
            case Player.States.ULTIMATE:
                break;
            case Player.States.DEAD:
                break;

        }
    }
    
    public void OnStateUpdate()
    {
        switch (player.currentStates)
        {
            case Player.States.IDLE:
                if(_direction.magnitude > 0f)
                { 
                    TransitionToState(Player.States.WALK);
                }
                if (_isJumped && player.isGrounded)
                {
                    TransitionToState(Player.States.JUMP);
                }
                if (_isPunched)
                {
                    TransitionToState(Player.States.PUNCH);
                }
                break;
            case Player.States.WALK: 
                transform.parent.Translate( moveSpeed * _direction * Time.deltaTime);
                if ( _direction.magnitude == 0f )
                {
                    TransitionToState(Player.States.IDLE);
                }
                if (_isJumped && player.isGrounded )
                {
                    TransitionToState(Player.States.JUMP);
                }
                if (_isPunched)
                {
                    TransitionToState(Player.States.PUNCH);
                }
                break;
                
            case Player.States.JUMP:
                
                transform.parent.Translate(moveSpeed * _direction * Time.deltaTime);
                
                    if (_rb2d.velocity.y < 0f)
                    {
                        TransitionToState(Player.States.FALL);
                    }
                
                break;
                
            case Player.States.FALL:
                
                transform.parent.Translate(moveSpeed * _direction * Time.deltaTime);

                if (player.isGrounded)
                {
                    if (_direction.magnitude == 0f)
                    {
                        TransitionToState(Player.States.IDLE);
                    }
                    else if (_direction.magnitude > 0f)
                    {
                        TransitionToState(Player.States.WALK);
                    }
                }
                break;

            case Player.States.PUNCH:
                transform.parent.Translate(moveSpeed * _direction * Time.deltaTime);
                

                if (punchFinish)
                {
                    if (_direction.magnitude == 0f)
                    {
                        TransitionToState(Player.States.IDLE);
                    }
                    if (_direction.magnitude > 0f)
                    {
                        TransitionToState(Player.States.WALK);
                    }
                }
                    break;   
            case Player.States.HURT:
                break;
            case Player.States.ULTIMATE:
                break;
            case Player.States.DEAD:
                break;
        }
    }

    public void OnStateExit()
    {
        switch (player.currentStates)
        {
            case Player.States.IDLE:
                break;
            case Player.States.WALK:
                break;
            case Player.States.PUNCH:
                moveSpeed = 5f;
               //animator.Setbool(false)
                break;
            case Player.States.JUMP:
                break;
            case Player.States.HURT:
                break;
            case Player.States.FALL:
                _rb2d.gravityScale = 0f;
                break;
            case Player.States.ULTIMATE:
                break;
            case Player.States.DEAD:
                break;
        }
    }

    public void TransitionToState(Player.States newState)
    {
        OnStateExit();
        player.currentStates = newState;
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
                //_isPunched = true;

                break;
            case InputActionPhase.Canceled:
                //_isPunched = false;
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
                Debug.Log("je prend");
                player.isGrabing = true;
                if(GrabObject.itemHolding != null)
                {
                    GrabObject.itemThrow = true;
                }
                
                break;
            case InputActionPhase.Canceled:
                player.isGrabing = false;
                break;
        }
    }
}
