using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    [SerializeField] private float _TTL = 2.0f;
	[SerializeField] private bool _random = false;
	[SerializeField] private float _range_min = 0.0f;
	[SerializeField] private float _range_max = 1.0f;
	
	private float _timer = 0;
	// Use this for initialization
	void Start () {
		if(_random)
		{
			_TTL = Random.Range(_range_min, _range_max);
		}
		_timer = _TTL;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTimer();
	}

    void UpdateTimer()
    {
        _timer -= Time.deltaTime;

        if(_timer <= 0.0f) Destroy(gameObject);
    }
}
