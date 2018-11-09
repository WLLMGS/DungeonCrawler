using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonTestScript : MonoBehaviour
{

    [SerializeField] private GameObject _room;
    [SerializeField] private GameObject _hallwayHorizontal;
	[SerializeField] private GameObject _hallwayVertical;
    // Use this for initialization
    void Start()
    {
        SpawnRoom(new Vector2(0, 0), true, false, true, false);
		SpawnRoom(new Vector2(29, 0), false, true, true, false);
    	SpawnRoom(new Vector2(0, 21), true, false, false, true);
    	SpawnRoom(new Vector2(29, 21), false, true, false, true);
    
	}

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRoom(Vector2 position, bool right, bool left, bool up, bool down)
    {
        Vector3 pos = position;
        pos.z = 20.0f;

        var room = Instantiate(_room, pos, Quaternion.identity);

        //enable correct colliders

        if (up)
        {
            room.transform.Find("Collider_Top_Half_1").gameObject.SetActive(true);
            room.transform.Find("Collider_Top_Half_2").gameObject.SetActive(true);
        }
        else
        {
            room.transform.Find("Collider_Top_Full").gameObject.SetActive(true);
        }

        if (down)
        {
            room.transform.Find("Collider_Down_Half_1").gameObject.SetActive(true);
            room.transform.Find("Collider_Down_Half_2").gameObject.SetActive(true);
        }
        else
        {
            room.transform.Find("Collider_Down_Full").gameObject.SetActive(true);
        }
        if (right)
        {
            //right
            room.transform.Find("Collider_Right_Half_1").gameObject.SetActive(true);
            room.transform.Find("Collider_Right_Half_2").gameObject.SetActive(true);
        }
        else
        {
            //right
            room.transform.Find("Collider_Right_Full").gameObject.SetActive(true);
        }

        if (left)
        {
            //right
            room.transform.Find("Collider_Left_Half_1").gameObject.SetActive(true);
            room.transform.Find("Collider_Left_Half_2").gameObject.SetActive(true);
        }
        else
        {
            //right
            room.transform.Find("Collider_Left_Full").gameObject.SetActive(true);
        }

        //spawn hallway
        if (right)
        {
            //spawn hallway
            SpawnHallwayHorizontal(room.transform.position);
        }
		if(up)
		{
			//spawn hallway
			SpawnHallwayVertical(room.transform.position);
		}
    }

	void SpawnHallwayVertical(Vector2 position)
	{
		float offset = 10.0f;
		Vector3 pos = position;
		pos.y += offset;
		Instantiate(_hallwayVertical, pos, Quaternion.identity);
	}

    void SpawnHallwayHorizontal(Vector2 position)
    {
        Debug.Log(position);
        Vector3 pos = position;
        pos.z = 15.0f;
        pos.x += 14.5f; //offset

        var hallway = Instantiate(_hallwayHorizontal, pos, Quaternion.identity);
    }
}
