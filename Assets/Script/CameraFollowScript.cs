using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

	private GameObject _player;
	[SerializeField] private float _Z = -100.0f;

	// Use this for initialization
	void Start () {
		_player = GameObject.Find("Cuby");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, _Z);
	}
}
