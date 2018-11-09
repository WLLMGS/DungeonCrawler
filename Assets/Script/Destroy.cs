using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    [SerializeField] private float _TTL = 2.0f;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTimer();
	}

    void UpdateTimer()
    {
        _TTL -= Time.deltaTime;

        if(_TTL <= 0.0f) Destroy(gameObject);
    }
}
