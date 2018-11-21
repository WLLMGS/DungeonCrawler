using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyHealthManager : MonoBehaviour
{

    private EnemyHealth _health;

    private EnemyExplosionScript _explosion;
    private CubyGameManager _gm;

	// Use this for initialization
	void Start ()
	{
	    _health = GetComponent<EnemyHealth>();
	    _explosion = GetComponent<EnemyExplosionScript>();
        _gm = CubyGameManager.GetInstance();
    }
	
	// Update is called once per frame
	void Update () {
		CheckIfAlive();
	}

    void CheckIfAlive()
    {
        if (!_health.IsAlive())
        {
            //drop loot
            _gm.DropCoin(transform.position);
            //do explosion
            _explosion.Explode();
            //destroy enemy
            Destroy(gameObject);
        }
    }
}
