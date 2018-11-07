using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour {

    [SerializeField] private float _maxmovementspeed = 2.0f;

    private GameObject _player;
    private Rigidbody2D _rigid;
	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Cuby");
        _rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        HandleMovement();
	}

    void HandleMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _maxmovementspeed * Time.deltaTime);
    }
}
