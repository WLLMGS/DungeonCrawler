using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpikePickup : PowerUpBase {
	[SerializeField] private GameObject _icespike;

	public override void PowerUp(GameObject player)
	{
		CheckForAbilities(player);
		player.AddComponent(typeof(IceSpikeAbility));
		player.GetComponent<IceSpikeAbility>().SetIceSpike(_icespike);
	}
}
