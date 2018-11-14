using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubyWeaponTracker : MonoBehaviour {

	private bool _HasWeapon = false;

	public bool HasWeapon()
	{
		return _HasWeapon;
	}

	public void SetHasWeapon(bool hasWeapon)
	{
		_HasWeapon = hasWeapon;
	}
}
