using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubyGameManager : MonoBehaviour
{
    private static CubyGameManager _instance = null;

    [SerializeField] List<GameObject> _weapons = new List<GameObject>();
    [SerializeField] List<GameObject> _items = new List<GameObject>();
    [SerializeField] private GameObject _coin;

    [SerializeField] private int _width = 0;
    [SerializeField] private int _height = 0;
    [SerializeField] private int _randomRooms = 3;
    [SerializeField] private int _itemRooms = 2;
    [SerializeField] private bool _doSpawnEnemies = false;

    private GameObject _cuby;
    private GameObject _minimapCam;
    private DungeonGenerator _levelGenerator;
    private EnemySpawner _enemySpawner;

    void Awake()
    {
        if (_instance == null) _instance = this;
    }

    void Start()
    {
        //init variables
        _cuby = GameObject.Find("Cuby");
        _minimapCam = GameObject.Find("MinimapCamera");
        _levelGenerator = DungeonGenerator.GetInstance();
        _enemySpawner = EnemySpawner.GetInstance();

        GenerateLevel();
    }

    void OnApplicationQuit()
    {
        DataWriter.SaveData();
    }

    private void GenerateLevel()
    {
        //clear level
        _levelGenerator.Clear();
        foreach (GameObject room in GameObject.FindGameObjectsWithTag("Room"))
        {
            Destroy(room);
        }
        //clear enemies
        _enemySpawner.Clear();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
        //clear items
        foreach (GameObject powerup in GameObject.FindGameObjectsWithTag("PowerUp"))
        {
            Destroy(powerup);
        }
        //clear effects
        foreach (GameObject effect in GameObject.FindGameObjectsWithTag("Effect"))
        {
            Destroy(effect);
        }
        //clear guns that are not picked up
        foreach(GameObject gun in GameObject.FindGameObjectsWithTag("Gun"))
        {
            if(!gun.GetComponent<WeaponPickupScript>().IsPickedUp)
            {
                Destroy(gun);
            }
        }
        
        //generate level
        _levelGenerator.GenerateLevel(_width, _height, _randomRooms, _itemRooms);

        //set cuby position to spawn room
        _cuby.transform.position = new Vector3(_levelGenerator.GetCubySpawnPos().x, _levelGenerator.GetCubySpawnPos().y, -5);
        _minimapCam.transform.position = new Vector3(_cuby.transform.position.x, _cuby.transform.position.y, -100);

        //init enemies
        if(_doSpawnEnemies) StartCoroutine(Init());
    }

    public static CubyGameManager GetInstance()
    {
        return _instance;
    }

    IEnumerator Init()
    {
        yield return new WaitForSeconds(0.1f);
        _enemySpawner.SpawnEnemies(5, 10);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E)) GenerateLevel();
    }

    public void SpawnWeapon(Vector3 location)
    {
        int index = Random.Range(0, _weapons.Count);
        Instantiate(_weapons[index], location, Quaternion.identity);
    }
    public GameObject SpawnItem(Vector3 location)
    {
        int index = Random.Range(0, _items.Count);
        GameObject item = Instantiate(_items[index], location, Quaternion.identity);
        _items.Remove(_items[index]); //remove from item pool
    
        return item;
    }
    public void DropCoin(Vector2 location)
    {
        Vector3 pos = location;
        pos.z = 0;
        Instantiate(_coin, pos, Quaternion.identity);
    }

    public void AdvanceLevel()
    {
        GenerateLevel();
    }
    
}
