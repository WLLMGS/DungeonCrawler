using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawnScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		CubyGameManager.GetInstance().SpawnWeapon(transform.position);
	}
	
}
