using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour {

	private GameObject _player;
	private float _zpos = -100.0f;

	// Use this for initialization
	void Start () {
		_player = GameObject.Find("Cuby");
	}
	
	// Update is called once per frame
	void Update () {
		HandleMovement();
	}
	void HandleMovement()
	{
		Vector3 pos = _player.transform.position;
		pos.z = _zpos;
		transform.position = pos;
	}
}
