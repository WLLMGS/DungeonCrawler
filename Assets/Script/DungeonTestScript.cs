using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonTestScript : MonoBehaviour {

    [SerializeField] private GameObject _room;
	[SerializeField] private GameObject _hallwaySideways;

	// Use this for initialization
	void Start () {
		SpawnRoom(new Vector2(0,0), true, false);
		SpawnRoom(new Vector2(29,0), false, true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnRoom(Vector2 position, bool right, bool left)
	{
		Vector3 pos = position;
		pos.z = 20.0f;

		var room = Instantiate(_room, pos, Quaternion.identity);

		//enable correct colliders
		//top
		room.transform.Find("Collider_Top_Full").gameObject.SetActive(true);
		//down
		room.transform.Find("Collider_Down_Full").gameObject.SetActive(true);
		
		if(right)
		{
			//right
			room.transform.Find("Collider_Right_Half_1").gameObject.SetActive(true);
			room.transform.Find("Collider_Right_Half_2").gameObject.SetActive(true);
		}
		else{
			//right
			room.transform.Find("Collider_Right_Full").gameObject.SetActive(true);
		}

		if(left)
		{
			//right
			room.transform.Find("Collider_Left_Half_1").gameObject.SetActive(true);
			room.transform.Find("Collider_Left_Half_2").gameObject.SetActive(true);
		}
		else{
			//right
			room.transform.Find("Collider_Left_Full").gameObject.SetActive(true);
		}

		//spawn hallway
		if(right)
		{
			Vector2 socketPos = room.transform.Find("SocketRight").position;
			//spawn hallway
			SpawnHallway(socketPos);
		}
	}

	void SpawnHallway(Vector2 socketPos)
	{
		Vector3 pos = socketPos;
		pos.z = 15.0f;

		var hallway = Instantiate(_hallwaySideways, pos, Quaternion.identity);
		Vector3 offset = hallway.transform.Find("SocketLeft").position;
		offset.z = 0;
		hallway.transform.position += offset;
	}
}
