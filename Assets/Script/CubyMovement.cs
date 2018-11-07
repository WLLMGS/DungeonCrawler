using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubyMovement : MonoBehaviour
{

    [SerializeField] private float _movespeed = 5.0f;
    [SerializeField] private float _maxspeed = 5.0f;

    private Rigidbody2D _rigid;

    // Use this for initialization
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float xaxis = Input.GetAxis("Horizontal");
        float yaxis = Input.GetAxis("Vertical");

        _rigid.AddForce(new Vector2(xaxis, yaxis) * _movespeed, ForceMode2D.Force);

        if (Mathf.Abs(_rigid.velocity.x) > _maxspeed)
        {
            _rigid.velocity = new Vector2(_maxspeed * Mathf.Sign(_rigid.velocity.x), _rigid.velocity.y);
        }

        if (Mathf.Abs(_rigid.velocity.y) > _maxspeed)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _maxspeed * Mathf.Sign(_rigid.velocity.y));
        }

		// if(xaxis == 0.0f )
		// {
		// 	_rigid.velocity = new Vector2(0, _rigid.velocity.y);
		// }


		// if(yaxis == 0.0f)
		// {
		// 	_rigid.velocity = new Vector2(_rigid.velocity.x, 0.0f);
		// }

       
    }
}
