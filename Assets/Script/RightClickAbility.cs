using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickAbility : MonoBehaviour
{

    [SerializeField] protected float _manaCost = 20.0f;
    protected PlayerStats _playerStats;

    private bool _IsPrimarySkill = false;

    public bool IsPrimarySkill
    {
        get
        {
            return _IsPrimarySkill;
        }
        set
        {
            _IsPrimarySkill = value;
        }
    }


    void Start()
    {
        _playerStats = PlayerStats.GetInstance();
    }

    void Update()
    {
        if (_IsPrimarySkill)
        {
            if (Input.GetMouseButtonDown(1)
                   && _playerStats.GetCurrentMana() >= _manaCost) // check if player has enough mana
            {
                Debug.Log(_manaCost);
                _playerStats.AddCurrentMana(-_manaCost); //reduce mana cost
                CameraShake.GetInstance().Shake();
                DoAbility();
            }
        }
		else{
			if (Input.GetKeyDown(KeyCode.Space)
                   && _playerStats.GetCurrentMana() >= _manaCost) // check if player has enough mana
            {
                Debug.Log(_manaCost);
                _playerStats.AddCurrentMana(-_manaCost); //reduce mana cost
                CameraShake.GetInstance().Shake();
                DoAbility();
            }
		}

    }

    public virtual void DoAbility()
    {     
    }

    public void SetManaCost(float cost)
    {
        _manaCost = cost;
    }

}


