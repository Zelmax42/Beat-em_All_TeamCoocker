using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPiouPiou : MonoBehaviour
{
    public Rigidbody2D _rb2d;
    public float _speed;
    public Transform _playerTarget;
    public Vector2 _bulletDirection;
    public Boss boss;
    public Player player;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _playerTarget = GameObject.FindGameObjectWithTag("Player").transform;


        _bulletDirection = _playerTarget.position - transform.position;
         float a = Mathf.Atan2(_bulletDirection.x, _bulletDirection.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -a);
        _rb2d.velocity = transform.up * _speed;
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            player.pvPlayer -= boss.piouPiouDamage;
        }
    }
}
