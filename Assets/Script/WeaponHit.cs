using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHit : MonoBehaviour {

	[SerializeField] private float _damage = 1.25f;

	private float _splatterRange = 0.5f; 

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			 GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>().Shake();
            col.gameObject.GetComponent<EnemyBloodScript>().SpawnBlood();
            col.gameObject.GetComponent<EnemyHealth>().AddHealth(-_damage);
		}
	}
}
