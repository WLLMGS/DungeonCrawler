using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpikeAbility : RightClickAbility {

	[SerializeField] private GameObject _icespike;
	
	public override void DoAbility()
	{
		int amount = 8;
		float angle = 0;
		for(int i = 0; i < amount; ++i)
		{
			Quaternion quat = Quaternion.Euler(new Vector3(0,0,angle));
			GameObject spike = Instantiate(_icespike, transform.position, quat);
			spike.GetComponent<BulletScript>().SetDirection(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
			spike.GetComponent<BulletScript>().SetDamage(_playerStats.GetDamage() * 3.0f);
			angle += 360.0f / (amount);
		}
	}

	public void SetIceSpike(GameObject icespike)
	{
		_icespike = icespike;
	}
}
