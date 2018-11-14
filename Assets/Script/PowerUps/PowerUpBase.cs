using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : MonoBehaviour {

	virtual public void PowerUp(GameObject player){}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			PowerUp(col.gameObject); //add power up to player
			Destroy(gameObject); //destroy the power up
		}
	}
}
