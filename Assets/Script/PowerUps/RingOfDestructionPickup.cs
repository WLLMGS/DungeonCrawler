using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class RingOfDestructionPickup : PowerUpBase {

// 	public override void PowerUp(GameObject player)
// 	{
// 		CheckForAbilities(player);
// 		RingOfDestructionAbility ab = (RingOfDestructionAbility) player.AddComponent(typeof(RingOfDestructionAbility));
// 		ab.SetManaCost(_manaCost);
// 	}
	
// }
public class RingOfDestructionPickup : SkillPickupBase {

	public override void AddSkill(GameObject player, bool isPrimarySkill)
	{
		RingOfDestructionAbility ab = (RingOfDestructionAbility) player.AddComponent(typeof(RingOfDestructionAbility));
		ab.IsPrimarySkill = isPrimarySkill;
		ab.SetManaCost(_manaCost);
	}
	
}