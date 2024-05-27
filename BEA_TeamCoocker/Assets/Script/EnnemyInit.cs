using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyInit : MonoBehaviour
{
    public float _nbHP;
    public float _damage;
    public float _speed;
    public States _Type;

    public enum States
    {
        NORMAL, BIG, SPEED
    }


    // Start is called before the first frame update
    void Awake()
    {
        switch (_Type)
        {
            case States.NORMAL:
                _nbHP = 3f;
                _damage = 1f;
                _speed = 2f;
                break;
            case States.BIG:
                _nbHP = 5f;
                _damage = 3f;
                _speed = 1f;
                break;
            case States.SPEED:
                _nbHP = 2f;
                _damage = 1f;
                _speed = 5f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
