using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour
{
    private Transform _target;
    private Vector2 _moveDirection;
    public float _movespeed = 5f;
    private Rigidbody2D _rb2d;
    public States _CurrentState = States.IDLE;
    public enum States
    {
        IDLE, WALK, PUNCH, HURTED, DEAD
    }
    // Start is called before the first frame update
    void Start()
    {
        //initialisation de la cible, donc du joueur
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        OnStateUpdate();
    }

    public void OnStateEnter()
    {
        switch(_CurrentState)
        {
            case States.IDLE:
                break;
            case States.WALK:
                break;
            case States.PUNCH:
                break;
            case States.HURTED:
                break;
            case States.DEAD:
                break;
            default:
                break;
        }
    }
    public void OnStateUpdate()
    {
        switch (_CurrentState)
        {
            case States.IDLE:
                break;
            case States.WALK:
                break;
            case States.PUNCH:
                break;
            case States.HURTED:
                break;
            case States.DEAD:
                break;
            default:
                break;
        }
    }

    public void OnStateExit()
    {
        switch (_CurrentState)
        {
            case States.IDLE:
                break;
            case States.WALK:
                break;
            case States.PUNCH:
                break;
            case States.HURTED:
                break;
            case States.DEAD:
                break;
            default:
                break;
        }
    }

    public void TransitionToState(States state)
    {
        OnStateExit();
        _CurrentState = state;
        OnStateEnter();
    }

    private void FixedUpdate()
    {
        if (_target != null)
        {
            _moveDirection = _target.position - transform.position;
        }
        Quaternion lookAt = Quaternion.LookRotation(_moveDirection, Vector3.back);
        _rb2d.SetRotation(lookAt);
        _rb2d.velocity = _moveDirection.normalized * _movespeed;
    }
}
