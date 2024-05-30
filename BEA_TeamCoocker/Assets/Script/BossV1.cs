using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossV1 : MonoBehaviour
{
    private Vector2 _moveDirection;
    public float _moveSpeed = 2f;
    public float _dashSpeed = 5f;
    public float _chrono = 0f;
    public float _chronoDash = 0f;
    private Transform _target;

    public States _currentState = States.IDLE;

    public enum States
    {
        IDLE, MOVE, ATTACK, HURT, DEAD
    }
    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        OnStateUpdate();
    }

    public void OnstateEnter()
    {
        switch (_currentState)
        {
            case States.IDLE:
                break;
            case States.MOVE:
                break;
            case States.ATTACK:
                break;
            case States.HURT:
                break;
            case States.DEAD:
                break;
        }
    }

    public void OnStateUpdate()
    {
        if (_chrono >=2f)
        {
            BossMovement();
            _chrono = 0f;
        }
        else
        {
            _chrono += Time.deltaTime;
        }
        if (_chronoDash >= 5f)
        {
            BossDash();
            _chronoDash = 0f;
        }

        switch (_currentState)
        {
            case States.IDLE:
                break;
            case States.MOVE:
                transform.parent.Translate(_moveSpeed * _moveDirection * Time.deltaTime);
                break;
            case States.ATTACK:
                break;
            case States.HURT:
                break;
            case States.DEAD:
                break;
        }
    }

    public void OnStateExit()
    {
        switch (_currentState)
        {
            case States.IDLE:
                break;
            case States.MOVE:
                break;
            case States.ATTACK:
                break;
            case States.HURT:
                break;
            case States.DEAD:
                break;
        }
    }

    public void TransitionToState(States state)
    {
        OnStateExit();
        _currentState = state;
        OnstateEnter();
    }

    public void BossMovement()
    {
        _moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        TransitionToState(States.MOVE);
    }
    public void BossDash()
    {
        if (_target != null)
        {
            _moveDirection = _target.position - transform.position;
            _moveDirection.Normalize();
        }
    }
}
