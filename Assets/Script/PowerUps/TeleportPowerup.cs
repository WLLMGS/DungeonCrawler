using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPowerup : PowerUpBase {

	public override void PowerUp(GameObject player)
	{
		//check if player has ability
		RightClickAbility ab = player.GetComponent<RightClickAbility>();
		if(ab != null) Destroy(ab);

		player.AddComponent(typeof(TeleportSkill));
	}
}
