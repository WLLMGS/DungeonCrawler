using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingStarAbilityPickup : SkillPickupBase {

	[SerializeField] private GameObject _star;

	public override void AddSkill(GameObject player, bool isPrimarySkill)
	{
		ThrowingStarAbility ab = (ThrowingStarAbility) player.AddComponent<ThrowingStarAbility>();
		ab.SetThrowingStar(_star);
		ab.IsPrimarySkill = isPrimarySkill;
		ab.SetManaCost(_manaCost);
	}
}
