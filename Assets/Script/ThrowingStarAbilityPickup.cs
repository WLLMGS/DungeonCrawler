using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingStarAbilityPickup : PowerUpBase {

	[SerializeField] private GameObject _star;

	public override void PowerUp(GameObject player)
	{
		CheckForAbilities(player);
		player.AddComponent(typeof(ThrowingStarAbility));
		player.GetComponent<ThrowingStarAbility>().SetThrowingStar(_star);
	}
}
