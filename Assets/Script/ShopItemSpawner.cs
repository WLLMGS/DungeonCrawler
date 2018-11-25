using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject spawnedItem = CubyGameManager.GetInstance().SpawnItem(transform.position);
		//add cost script 
		ShopItemScript script = (ShopItemScript) spawnedItem.AddComponent(typeof(ShopItemScript));

		script.Cost = Random.Range(10,50);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
