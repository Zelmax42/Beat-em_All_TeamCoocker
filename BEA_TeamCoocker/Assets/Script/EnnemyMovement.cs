using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour
{
    #region Variables

    private Rigidbody2D _rb2d;
    public float _nbPV = 1;
    public float _damage;
    public float _speed;
    public bool _isDefeated = false;
    private bool _isHurted = false;
    private float chrono = 0f;
    public Animator _animator;

    public EnnemyInit mobInit;
    public Player _player;

    private Transform _target;
    private Vector2 _moveDirection;
    public float _movespeed = 5f;
    private float _currentSpeed;
    public States _CurrentState= States.IDLE;

    public enum States
    {
        IDLE, WALK, PUNCH, HURTED, DEAD
    }
    #endregion

    #region UnityLifeCycle
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        _nbPV = mobInit._nbHP;
        _movespeed = mobInit._speed;
        _damage = mobInit._damage;

        //initialisation de la cible, donc du joueur
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        OnStateUpdate();

        if (_nbPV <= 0f)
        {
            _isDefeated = false;
            _animator.SetFloat("Life", 0f);
            TransitionToState(States.HURTED);
        }
    }

    private void FixedUpdate()
    {
        _rb2d.velocity = _moveDirection.normalized * _currentSpeed;
    }

    #endregion


    #region StateMachine

    public void OnStateEnter()
    {
        switch(_CurrentState)
        {
            case States.IDLE:
                _currentSpeed = 0f;
                _animator.SetFloat("Velocity", 0f);
                break;
            case States.WALK:
                _currentSpeed = _movespeed;
                _animator.SetFloat("Velocity", 1f);
                break;
            case States.PUNCH:
                _currentSpeed = 0f;
                _animator.SetTrigger("Attack");
                _player.pvPlayer -= _damage;
                break;
            case States.HURTED:
                _currentSpeed = 0f;
                _animator.SetTrigger("Hurted");


                _isHurted = false;

                break;
            case States.DEAD:
                _currentSpeed = 0f;
                
                gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
    public void OnStateUpdate()
    {
        if (chrono >=2f)
        {
            RandomStates();
            chrono = 0;
        }
        else
        {
            chrono += Time.deltaTime;
        }


        if (_isHurted)
        {
            TransitionToState(States.HURTED);
        }

        switch (_CurrentState)
        {
            case States.IDLE:

                break;
            case States.WALK:

                break;
            case States.PUNCH:
                break;
            case States.HURTED:

                if (_isDefeated)
                {
                    TransitionToState(States.DEAD);
                }
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

    #endregion

    #region Methods

    public void OnTriggerEnter2D(Collider2D collision)
    {
        TransitionToState(States.PUNCH);

    }

    public void RandomStates()
    {
        float _ProbaState = Mathf.Round(Random.Range(0,3));
        switch (_ProbaState)
        {
            case 0:
                TransitionToState(States.IDLE);
                break;
            case 1:

                _moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                if (_moveDirection.x < 0)
                {
                    transform.localEulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                }

                TransitionToState(States.WALK);
                break;
            case 2:

                if (_target != null) // Si il y a une cible (Player), on le vise
                {
                    _moveDirection = _target.position - transform.position;
                }

                if (_moveDirection.x < 0)
                {
                    transform.localEulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                TransitionToState(States.WALK);
                break;
        }
    }

    public void GotDamaged(float damage)
    {
        _nbPV -= damage;
        _isHurted = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("mob touché");
        _nbPV -= _player.dmgPlayer;
    }

    #endregion
}
