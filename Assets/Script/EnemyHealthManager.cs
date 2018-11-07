using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyHealthManager : MonoBehaviour
{

    private EnemyHealth _health;

    private EnemyExplosionScript _explosion;

	// Use this for initialization
	void Start ()
	{
	    _health = GetComponent<EnemyHealth>();
	    _explosion = GetComponent<EnemyExplosionScript>();
	}
	
	// Update is called once per frame
	void Update () {
		CheckIfAlive();
	}

    void CheckIfAlive()
    {
        if (!_health.IsAlive())
        {
            //do explosion
            _explosion.Explode();
            //destroy enemy
            Destroy(gameObject);
        }
    }
}
