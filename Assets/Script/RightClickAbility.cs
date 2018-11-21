using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickAbility : MonoBehaviour {

	[SerializeField] protected float _manaCost = 20.0f;
	protected PlayerStats _playerStats;

	// Use this for initialization
	void Start () {
		_playerStats = PlayerStats.GetInstance();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1)
		&& _playerStats.GetCurrentMana() >= _manaCost) // check if player has enough mana
		{
			_playerStats.AddCurrentMana(-_manaCost); //reduce mana cost
			CameraShake.GetInstance().Shake();
			DoAbility();
		}
	}

	public virtual void DoAbility()
	{
		Debug.Log("DO RIGHT CLICK ABILITY");
	}

}


