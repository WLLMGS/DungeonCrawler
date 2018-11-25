using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfDestructionAbility : RightClickAbility {

	public override void DoAbility()
	{
		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pos.z = 0.0f;

		EffectManager.GetInstance().SpawnEffect(2, pos, 3);
	}
}
