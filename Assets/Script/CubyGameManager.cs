using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubyGameManager : MonoBehaviour
{
    private static CubyGameManager _instance = null;

    [SerializeField] List<GameObject> _weapons = new List<GameObject>();
    [SerializeField] List<GameObject> _items = new List<GameObject>();

    private GameObject _cuby;
    private GameObject _minimapCam;
    private DungeonGenerator _levelGenerator;
    private EnemySpawner _enemySpawner;

    void Awake()
    {
        if(_instance == null) _instance = this;
    }

    void Start()
    {
        //init variables
        _cuby = GameObject.Find("Cuby");
        _minimapCam = GameObject.Find("MinimapCamera");
        _levelGenerator = DungeonGenerator.GetInstance();
        _enemySpawner = EnemySpawner.GetInstance();

        //generate level
        _levelGenerator.GenerateLevel(5, 5, 3);

        //set cuby position to spawn room
        _cuby.transform.position = new Vector3(_levelGenerator.GetCubySpawnPos().x, _levelGenerator.GetCubySpawnPos().y, -5);
        _minimapCam.transform.position = new Vector3(_cuby.transform.position.x, _cuby.transform.position.y, -100);

        //init enemies
        StartCoroutine(Init());
    }
    
    public static CubyGameManager GetInstance()
    {
        return _instance;
    }
    
    IEnumerator Init()
    {
		yield return new WaitForSeconds(0.1f);
		_enemySpawner.SpawnEnemies();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) _enemySpawner.SpawnEnemies();
    }

    public void SpawnWeapon(Vector3 location)
    {
        int index = Random.Range(0, _weapons.Count);
        Instantiate(_weapons[index], location, Quaternion.identity);
    }
    public void SpawnItem(Vector3 location)
    {
        int index = Random.Range(0, _items.Count);
        Instantiate(_items[index], location, Quaternion.identity);
    }
}
