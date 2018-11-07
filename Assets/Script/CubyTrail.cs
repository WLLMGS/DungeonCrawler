using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubyTrail : MonoBehaviour {

	[SerializeField] GameObject _splatter;

	float _cooldown = 0.05f;
	 float _timer = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HandleSpawning();
	}

	void HandleSpawning()
	{
		_timer -= Time.deltaTime;

		if(_timer <= 0.0f)
		{
			_timer = _cooldown;

			float randAngle = Random.Range(0.0f,180.0f);

			Instantiate(_splatter, transform.position + new Vector3(0,0,6),  Quaternion.Euler(new Vector3(0,0,randAngle)));
		}
	}
}
