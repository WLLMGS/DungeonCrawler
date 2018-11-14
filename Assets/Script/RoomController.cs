using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour {

	private List<GameObject> _enemiesInRoom = new List<GameObject>();
	
	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			//activate enemies
			ActivateEnemies(true);
		}
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			//de-activate enemies
			ActivateEnemies(false);
		}
	}

	private void ActivateEnemies(bool activate)
	{
		foreach(GameObject enemy in _enemiesInRoom)
		{
			if(enemy) enemy.GetComponent<EnemyMovementScript>().Activate(activate);
		}
	}

	public void AddEnemy(GameObject enemy)
	{
		_enemiesInRoom.Add(enemy);
	}
}
