using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private float _health = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    
	}

    public void AddHealth(float health)
    {
        _health += health;
    }

    public bool IsAlive()
    {
        return _health > 0;
    }
}
