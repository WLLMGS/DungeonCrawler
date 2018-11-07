using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterBehavior : MonoBehaviour {

	float _decaytime = 0.2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateScale();
	}

	void UpdateScale()
	{
		Vector2 localscale = transform.localScale;

		localscale -= new Vector2(_decaytime,_decaytime) * Time.deltaTime;

		transform.localScale = localscale;

		if(localscale.x <= 0) Destroy(gameObject);
	}
}
