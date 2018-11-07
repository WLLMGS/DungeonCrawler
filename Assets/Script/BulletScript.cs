using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    [SerializeField] private float _movespeed = 5.0f;

    private Vector2 _direction = Vector2.zero;
    private Rigidbody2D _rigid;
    private float _damage = 0;

	void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate () {
        HandleMovement();
	}
    public void HandleMovement()
    {
        _rigid.velocity = _direction * _movespeed;
    }
    public void SetDirection(float x, float y)
    {
        _direction.x = x;
        _direction.y = y;
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyBloodScript>().SpawnBlood();
            col.gameObject.GetComponent<EnemyHealth>().AddHealth(-_damage);
            Destroy(gameObject);
        }
    }
}
