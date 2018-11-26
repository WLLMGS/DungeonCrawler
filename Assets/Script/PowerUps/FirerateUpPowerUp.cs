using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirerateUpPowerUp : PowerUpBase {

	public override void PowerUp(GameObject player)
	{
		PlayerStats.GetInstance().Firerate -= 0.4f;
	}

}
