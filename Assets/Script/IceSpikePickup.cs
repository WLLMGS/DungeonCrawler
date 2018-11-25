using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class IceSpikePickup : PowerUpBase {
// 	[SerializeField] private GameObject _icespike;

// 	public override void PowerUp(GameObject player)
// 	{
// 		CheckForAbilities(player);
// 		player.AddComponent(typeof(IceSpikeAbility));
// 		player.GetComponent<IceSpikeAbility>().SetIceSpike(_icespike);
// 	}
// }

public class IceSpikePickup : SkillPickupBase{
	[SerializeField] private GameObject _icespike;

	public override void AddSkill(GameObject player, bool isPrimarySkill)
	{
		player.AddComponent(typeof(IceSpikeAbility));
		IceSpikeAbility ab = (IceSpikeAbility) player.GetComponent<IceSpikeAbility>();
		ab.SetIceSpike(_icespike);
		ab.IsPrimarySkill = isPrimarySkill;
		ab.SetManaCost(_manaCost);
	}
}

