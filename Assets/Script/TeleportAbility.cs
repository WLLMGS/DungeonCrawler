using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSkill : RightClickAbility
{
	public override void DoAbility()
	{
		Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float z = transform.position.z;
		transform.position = new Vector3(mousepos.x, mousepos.y, z);

		Vector3 pos = new Vector3(mousepos.x, mousepos.y, -50);

		EffectManager.GetInstance().SpawnEffect(0, pos); //teleport effect particles
		EffectManager.GetInstance().SpawnEffect(1, transform.position + new Vector3(0,0,2), 2 ); //teleport mark
	}
}
