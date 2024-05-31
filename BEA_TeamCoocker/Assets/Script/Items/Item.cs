using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Item : MonoBehaviour
{
    public ObjectData objectData;
    public float spawnRadius = 10f;
    public float currentUsure;
    public bool isPickUp;
    public bool isThrow;

    public bool isVieux;
    public float speed;
    private float _currentSpeed = 0f;
    private Vector2 _moveDirection;
    private float _chrono = 0f;

    private Animator _animator;
    private Clamping _clamp;

    private void Start()
    {
        isThrow = false;
        currentUsure = objectData.usure;
        _animator = GetComponentInChildren<Animator>();
        _clamp = Camera.main.GetComponent<Clamping>();

        //Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
        //transform.position = new Vector3(randomPosition.x, randomPosition.y, transform.position.z);
    }

    private void Update()
    {
        if (isVieux)
        {
            if(!isPickUp && !isThrow)
            {
                RandomMove();
            }
            else
            {
                _currentSpeed = 0f;
                _moveDirection = Vector2.zero;
            }
            _animator.SetFloat("Velocity", _currentSpeed);
            _animator.SetBool("isGrabbed", isPickUp);
            transform.Translate(_currentSpeed * _moveDirection * Time.deltaTime);
            _clamp.ClampPosition(transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.gameObject.layer == 7 && isThrow)
        {
            Debug.Log("je touche");
            try
            {
                collision.GetComponent<EnnemyMovement>().GotDamaged(objectData.damage);
            }
            catch (System.Exception) { }
            try
            {
                collision.GetComponent<BossV1>().GotDamaged(objectData.damage);
            }
            catch (System.Exception) { }
            Damaged();
            GetComponent<ObjectThrow>().Bonked();
        }

    }

    public void Drop() 
    { 
        if (objectData.lootTable.Length > 0 ) 
        {                   
            int randomIndex = Random.Range(0, objectData.lootTable.Length);
            Instantiate(objectData.lootTable[randomIndex], transform.position, Quaternion.identity);    
        }
    }

    public void Damaged() 
    { 
        if(currentUsure == objectData.usure) 
        { 
            Drop();
        }
        currentUsure--;

        if(currentUsure <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }


    public void RandomMove()
    {
        if (_chrono >= 2f)
        {
            _chrono = 0f;
        
            float _ProbaState = Mathf.Round(Random.Range(0, 2));
            switch (_ProbaState)
            {
                case 0:
                    _currentSpeed = 0f;
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

                    _currentSpeed = speed;
                    break;
            }
        }
        else
        {
            _chrono += Time.deltaTime;
        }

        
    }
}