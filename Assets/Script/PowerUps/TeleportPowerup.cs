using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPowerup : SkillPickupBase {

	public override void AddSkill(GameObject player, bool isPrimarySkill)
	{
		//check if player has ability
		TeleportSkill ab = (TeleportSkill) player.AddComponent(typeof(TeleportSkill));
		ab.IsPrimarySkill = isPrimarySkill;
		ab.SetManaCost(_manaCost);
	}
}
