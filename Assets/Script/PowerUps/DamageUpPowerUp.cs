using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpPowerUp : PowerUpBase {

	public override void PowerUp(GameObject player)
	{
		PlayerStats.GetInstance().Damage += 0.5f;
	}
}
