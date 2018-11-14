using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotPowerup : PowerUpBase {

	public override void PowerUp(GameObject player)
	{
		Debug.Log("Double shot activated");
		var gunscript = player.GetComponentInChildren<GunScript>();
		if(gunscript)
		{
			gunscript.MultiplyBulletsPerShot(2);
			gunscript.SetAngleBetweenShot(5.0f);
		}
	}
}
