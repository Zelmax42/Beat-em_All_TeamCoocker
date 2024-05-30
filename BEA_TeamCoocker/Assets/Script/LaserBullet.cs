using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    public float _bulletSpeed = 20f;
    public float _laserDamage;
    private Rigidbody2D _bulletRigidbody;
    private float _chrono = 0f;
    public Player _player;
    public Boss boss;

    // Start is called before the first frame update
    void Start()
    {
        _bulletRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _chrono += Time.deltaTime;
        transform.localScale = new Vector3(-1 * _bulletSpeed * _chrono,1,1);
        Destroy(gameObject, 1f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            _player.pvPlayer -= boss.laserDamage;            
        }
    }
}
