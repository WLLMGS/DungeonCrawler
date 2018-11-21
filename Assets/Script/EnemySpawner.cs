using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject _enemy;

    private List<GameObject> _rooms = new List<GameObject>();
    private float _zpos = 1.0f;

    private static EnemySpawner _instance = null;


    void Awake()
    {
        if (_instance == null) _instance = this;
    }

    // Use this for initialization
    void Start()
    {
        _rooms = DungeonGenerator.GetInstance().GetRooms();
    }

    public static EnemySpawner GetInstance()
    {
        return _instance;
    }

    public void SpawnEnemies(int min, int max)
    {   
        foreach (GameObject room in _rooms)
        {
            
            if (room.GetComponent<RoomStats>().GetRoomType() == RoomType.BasicRoom) //only spawn enemies in basic rooms :)
            {
                
                Vector3 spawnradius_max = room.transform.Find("SpawnRadius_max").position; //get max spawn pos
                Vector3 spawnradius_min = room.transform.Find("SpawnRadius_min").position; // get min spawn pos
				
				int amount = Random.Range(min,max);
               
			   	for(int i = 0; i < amount ; ++i){
					//determine spawn pos
					Vector3 pos = new Vector3();
					pos.x = Random.Range(spawnradius_min.x, spawnradius_max.x);
					pos.y = Random.Range(spawnradius_min.y, spawnradius_max.y);
					pos.z = _zpos;
					//spawn enemy
					GameObject enemy = Instantiate(_enemy, pos, Quaternion.identity);
					//add the enemy to the room controller !
					room.GetComponent<RoomController>().AddEnemy(enemy);

                   
				}
            }
        }
    }

    public void Clear()
    {
        _rooms.Clear();
    }
}
