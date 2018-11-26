using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaRegenPowerup : PowerUpBase {

	public override void PowerUp(GameObject player)
	{
		PlayerStats.GetInstance().ManaPerSecond += 5.0f;
	}
}
