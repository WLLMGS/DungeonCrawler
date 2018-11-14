using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		CubyGameManager.GetInstance().SpawnItem(transform.position);
	}
	
	
}
