using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
	private float _maxforce = 12.0f;
	private float _threshold = 0.1f;
    private GameObject _player;
    private Rigidbody2D _rigid;
    // Use this for initialization
    void Start()
    {
        _player = GameObject.Find("Cuby");
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 force = Vector2.zero;
	    Vector2 target = _player.transform.position;
		Vector2 pos = transform.position;
		
		Vector2 distance = target - pos;
		
		if(distance.x > _threshold) force.x = _maxforce;
		else if(distance.x < -_threshold) force.x = -_maxforce;
		else force.x = 0;

		if(distance.y > _threshold) force.y = _maxforce;
		else if(distance.y < -_threshold) force.y = -_maxforce;
    	else force.y = 0;
		
		_rigid.velocity = force;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
