using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	[SerializeField] private float _firerate = 2.0f;
	[SerializeField] private float _damage = 1.0f;
	//health

	//mana
	[SerializeField] private float _manaPerSecond = 10.0f;
	[SerializeField] private float _manaPerShot = 5.0f;
	[SerializeField] private float _maxMana = 100.0f;
	[SerializeField] private float _currentMana = 0;

	//money
	[SerializeField] private int _currentGold;
	
	
	public int Gold{
		get{
			return _currentGold;
		}
		set
		{
			_currentGold = value;
		}
	}

	public float ManaPerSecond
	{
		get{
			return _manaPerSecond;
		}
		set{
			_manaPerSecond = value;
		}
	}

	public float Damage
	{
		get{
			return _damage;
		}
		set{
			_damage = value;
		}
	}

	public float Firerate
	{
		get{
			return _firerate;
		}
		set
		{
			_firerate = value;
			Mathf.Clamp(_firerate, 0.01f,3.0f); //make sure firerate doesnt go under 0
		}
	}

	private static PlayerStats _instance = null;

	void Awake()
	{
		if(_instance == null) _instance = this;

		_currentMana = _maxMana;
	}

	public static PlayerStats GetInstance()
	{
		return _instance;
	}

	void Update()
	{
		//mana regen
		CalculateManaRegen();
		//health regen

	}

  

	

	//mana
	public void AddCurrentMana(float mana)
	{
		_currentMana += mana;
		_currentMana = Mathf.Clamp(_currentMana, 0, _maxMana); //so that mana doesnt go over max or below zero 
	}

	public float GetCurrentMana()
	{
		return _currentMana;
	}

	public void SetMaxMana(float mana)
	{
		_maxMana = mana;
	}

	public float GetMaxMana()
	{
		return _maxMana;
	} 

	private void CalculateManaRegen()
	{
		AddCurrentMana(_manaPerSecond * Time.deltaTime); 
	}

	public void AddManaPerShot()
	{
		AddCurrentMana(_manaPerShot);
	}
}
