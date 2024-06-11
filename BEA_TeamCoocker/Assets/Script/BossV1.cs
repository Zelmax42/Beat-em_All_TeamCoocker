using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossV1 : MonoBehaviour
{
    #region Variables

    public Boss boss;
    public GameManagerSO win;

    [Header("Mouvement")]
    public Vector2 _moveDirection;
    public float _chrono = 0f;
    public bool isInArena;

    [Header("Attack")]
    public float _chronoDash = 0f;
    public float _chronoLaser = 0f;
    public float _chronoVisee = 0f;
    public float _chronoPiou = 0f;
    public Transform _target;
    public GameObject _laserBullet;
    public GameObject _laserPiouPiou;
    public GameObject _viseurLaser;
    public GameObject _bossHitBox;

    [Header("Life")]
    private bool _isHurted = false;

    public Clamping _clamp;
    public States _currentState = States.IDLE;

    public AudioSource hurtSFX;

    public enum States
    {
        IDLE, MOVE, HURT, DEAD, DASH
    }

    #endregion


    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _viseurLaser = GameObject.FindGameObjectWithTag("ViseeLaser");
        _viseurLaser.SetActive(false);
        _bossHitBox = GameObject.FindGameObjectWithTag("BossHitBox");
        _bossHitBox.SetActive(false);
        _clamp = Camera.main.GetComponent<Clamping>();
        boss.isActive = false;
        boss.bossHP = 30;
        isInArena = true;
    }

    void Update()
    {
        OnStateUpdate();
        BossRotate();

        if(boss.bossHP <= 0)
        {
            win.CheckWin();
        }
    }

    public void OnstateEnter()
    {
        switch (_currentState)
        {
            case States.IDLE:
                break;
            case States.MOVE:
                if (isInArena)
                {
                    BossMovement();
                }
                
                break;
            case States.DASH:
                _bossHitBox.SetActive(true);
                BossDash();
                break;
            case States.HURT:

                break;
            case States.DEAD:
                break;
        }
    }

    public void OnStateUpdate()
    {
        if (_chronoPiou >= 1f)
        {
            Shoot();
            _chronoPiou = 0f;
        }
        else
        {
            _chronoPiou += Time.deltaTime;
        }
        
        if (_chrono >= 2f && _currentState!=States.DASH && isInArena)
        {
            RandomStates();
            _chrono = 0f;
        }
        else if (!isInArena)
        {
            _moveDirection = _target.position - transform.position;
            TransitionToState(States.MOVE);
        }
        else
        {
            _chrono += Time.deltaTime;
        }
        if (_chronoDash >= 5f && _chronoLaser < 10f && _currentState!=States.DASH)
        {
            TransitionToState(States.DASH);
        }
        else
        {
            _chronoDash += Time.deltaTime;
        }
        if (_chronoLaser >= 10f)
        {
            LaserAttack();
        }
        else
        {
            _chronoLaser += Time.deltaTime;
        }

        if (_isHurted)
        {
            TransitionToState(States.HURT);
        }
        switch (_currentState)
        {
            case States.IDLE:               
                break;
            case States.MOVE:
                transform.parent.Translate(boss.moveSpeed * _moveDirection * Time.deltaTime);
                _clamp.ClampPosition(transform.parent);
                break;
            case States.DASH:
                transform.parent.Translate(boss.dashSpeed * _moveDirection * Time.deltaTime);
                _clamp.ClampPosition(transform.parent);
                if (_chronoDash>= 6f)
                {
                    RandomStates();
                }
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
            case States.DASH:
                _chronoDash = 0f;
                _bossHitBox.SetActive(false);
                break;
            case States.HURT:
                _isHurted = false;
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.FindGameObjectWithTag("PlayerHitBox"))
        {
            _isHurted = true;
        }
    }

    public void BossMovement()
    {
        _moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    public void BossRotate()
    {
        if (transform.position.x < _target.position.x)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
    public void BossDash()
    {
        if (_target != null)
        {
            _moveDirection = _target.position - transform.position;
            //_moveDirection.Normalize();
            
        }
    }

    public void Shoot()
    {
        Instantiate(_laserPiouPiou, GameObject.FindGameObjectWithTag("Canon").transform.position, Quaternion.identity);
    }

    public void LaserAttack()
    {
        //On affiche un trait symbolisant la visée du Boss
        _viseurLaser.SetActive(true);

        if (_chronoVisee >= 2f)
        {
            //Le boss pense avoir trouvé une cible, il s'arrete quelques instant
            _moveDirection = Vector2.zero;

            //le laser tire
            Instantiate(_laserBullet, GameObject.FindGameObjectWithTag("Canon").transform.position, GameObject.FindGameObjectWithTag("Canon").transform.rotation);

            //on réInit le chrono de la visée pour le prochain tir
            _chronoVisee = 0f;
            //On desactive la visee laser
            _viseurLaser.SetActive(false);
            _chronoLaser = 0f;
            _chronoDash = 1f;
        }
        else
        {
            _chronoVisee += Time.deltaTime;
        }
    }
    public void RandomStates()
    {
        float _ProbaState = Mathf.Round(Random.Range(0, 2));
        switch (_ProbaState)
        {
            case 0:
                TransitionToState(States.IDLE);
                break;
            case 1:
                TransitionToState(States.MOVE);
                break;

        }
    }
    public void GotDamaged(float value)
    {
        boss.bossHP -= value;
        hurtSFX.Play();
    }

    /*
    public void OnEnable()
    {
        boss.isActive = true;
    }*/
}
