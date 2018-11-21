using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DungeonGenerator : MonoBehaviour
{

    [SerializeField] private GameObject _room;
    [SerializeField] private GameObject _hallwayHorizontal;
    [SerializeField] private GameObject _hallwayVertical;
    [SerializeField] private int _width = 12;
    [SerializeField] private int _height = 12;
    [SerializeField] private List<GameObject> _startRoomLayouts = new List<GameObject>();
    [SerializeField] private List<GameObject> _itemRoomLayouts = new List<GameObject>();

    float _yOffset = 21.0f;
    float _xOffset = 29.0f;
    float _xHallwayOffset = 14.5f;
    float _yHallwayOffset = 10.0f;

    private int[,] _layout;

    private static DungeonGenerator _instance;

    private List<GameObject> _rooms = new List<GameObject>();

    Vector2 _cubySpawnPos = Vector2.zero;

    void Awake()
    {
        if (_instance == null) _instance = this;
    }

    public static DungeonGenerator GetInstance()
    {
        return _instance;
    }
    public void GenerateLevel(int w, int h, int r, int itemrooms)
    {
        _width = w;
        _height = h;

        _layout = new int[_width, _height];

        for (int x = 0; x < _width; ++x)
        {
            for (int y = 0; y < _height; ++y)
            {
                _layout[x, y] = 0;
            }
        }



        //generate the special rooms in each corner 
        GenerateStarterRooms();

        //add some random rooms
        GenerateRandomRooms(r);

        //add middle room
        _layout[_width / 2 + 1, _height / 2 + 1] = 1;

        //add the rooms to the scene w/ the correct hallways
        AddRooms();

        //add item rooms
        AddItemRooms(itemrooms);

        //add spawn room
        AddSpawnroom();

        //add room layouts
        AddRoomLayouts();
    }
    private void GenerateStarterRooms()
    {
        //q1
        int x = Random.Range(0, _width / 2);
        int y = Random.Range(0, _height / 2);
        _layout[x, y] = 1;
        ConnectRoomToCenter(x, y);

        //q2
        x = Random.Range(_width / 2 + 1, _width / 2 + _width / 2);
        y = Random.Range(0, _height / 2);
        _layout[x, y] = 1;
        ConnectRoomToCenter(x, y);

        //q3
        x = Random.Range(0, _width / 2);
        y = Random.Range(_height / 2 + 1, _height / 2 + _height / 2);
        _layout[x, y] = 1;
        ConnectRoomToCenter(x, y);

        //q4
        x = Random.Range(_width / 2 + 1, _width / 2 + _width / 2);
        y = Random.Range(_height / 2 + 1, _height / 2 + _height / 2);
        _layout[x, y] = 1;
        ConnectRoomToCenter(x, y);

    }
    private void GenerateRandomRooms(int amount)
    {
        for (int i = 0; i < amount; ++i)
        {

            int x = Random.Range(0, _width);
            int y = Random.Range(0, _height);

            _layout[x, y] = 8;
            ConnectRoomToCenter(x, y);
        }
    }
    GameObject SpawnRoom(Vector2 position, bool right, bool left, bool up, bool down)
    {
        Vector3 pos = position;
        pos.z = 20.0f;

        GameObject room = Instantiate(_room, pos, Quaternion.identity);

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
        if (up)
        {
            //spawn hallway
            SpawnHallwayVertical(room.transform.position);
        }

        return room;
    }

    void SpawnHallwayVertical(Vector2 position)
    {
        Vector3 pos = position;
        pos.y += _yHallwayOffset;
        Instantiate(_hallwayVertical, pos, Quaternion.identity);
    }

    void SpawnHallwayHorizontal(Vector2 position)
    {
        Vector3 pos = position;
        pos.z = 15.0f;
        pos.x += _xHallwayOffset; //offset

        var hallway = Instantiate(_hallwayHorizontal, pos, Quaternion.identity);
    }

    void PrintLayout()
    {
        string log = "";
        for (int x = 0; x < _width; ++x)
        {
            for (int y = 0; y < _height; ++y)
            {
                log += (_layout[y, x]).ToString() + " ";
            }

            log += "\n";
        }
        Debug.Log(log);
    }
    void ConnectRoomToCenter(int x, int y)
    {
        int middlex = _width / 2 + 1;
        int middley = _height / 2 + 1;

        int corridortype = Random.Range(0, 2);

        if (corridortype == 0)
        {
            if (middlex > x)
            {

                float dx = middlex - x;

                for (int xs = 0; xs < dx; ++xs)
                {
                    int index = x + xs + 1;
                    _layout[index, y] = 1;
                }
            }
            else
            {
                float dx = x - middlex;

                for (int xs = 0; xs < dx; ++xs)
                {
                    int index = middlex + xs;
                    _layout[index, y] = 1;
                }
            }

            if (middley > y)
            {

                float dy = middley - y;

                for (int ys = 0; ys < dy; ++ys)
                {

                    int index = ys + y;
                    _layout[middlex, index] = 1;

                }

            }
            else
            {

                float dy = y - middley;

                for (int ys = 0; ys < dy; ++ys)
                {

                    int index = ys + middley;
                    _layout[middlex, index] = 1;

                }

            }
        }
        else
        {
            if (middley > y)
            {

                float dy = middley - y;

                for (int ys = 0; ys < dy; ++ys)
                {

                    int index = ys + y;
                    _layout[x, index] = 1;

                }

            }
            else
            {

                float dy = y - middley;
                dy += 1;

                for (int ys = 0; ys < dy; ++ys)
                {

                    int index = ys + middley;
                    _layout[x, index] = 1;

                }
            }
            if (middlex > x)
            {

                float dx = middlex - x;

                for (int xs = 0; xs < dx; ++xs)
                {
                    int index = x + xs + 1;
                    _layout[index, middley] = 1;
                }
            }
            else
            {
                float dx = x - middlex;

                for (int xs = 0; xs < dx; ++xs)
                {
                    int index = middlex + xs;
                    _layout[index, middley] = 1;
                }
            }
        }
    }
    void AddRooms()
    {

        for (int x = 0; x < _width; ++x)
        {
            for (int y = 0; y < _height; ++y)
            {

                if (_layout[x, y] != 0)
                {

                    Vector2 pos = new Vector2(x * _xOffset, y * _yOffset);
                    GameObject room = SpawnRoom(pos, HasRight(x, y), HasLeft(x, y), HasUp(x, y), HasDown(x, y));
                    _rooms.Add(room);

                    // switch (_layout[x, y])
                    // {
                    //     case 1:
                    //         room.GetComponent<RoomStats>().SetRoomType(RoomType.SpawnRoom);
                    //         int rindex = Random.Range(0, _startRoomLayouts.Count); //determine random index for layout
                    //         Instantiate(_startRoomLayouts[rindex], room.transform.position, Quaternion.identity); //spawn starter room layout
                    //         break;
                    //     case 2:
                    //         room.GetComponent<RoomStats>().SetRoomType(RoomType.BasicRoom);

                    //         break;
                    //     case 3:
                    //         room.GetComponent<RoomStats>().SetRoomType(RoomType.SpecialRoom);
                    //         int sindex = Random.Range(0, _itemRoomLayouts.Count);
                    //         Instantiate(_itemRoomLayouts[sindex], room.transform.position, Quaternion.identity);
                    //         break;
                    // }

                }
            }
        }
    }

    private bool HasRight(int x, int y)
    {
        try { return (_layout[x + 1, y] == 0) ? false : true; }
        catch { return false; }
    }

    private bool HasUp(int x, int y)
    {
        try { return (_layout[x, y + 1] == 0) ? false : true; }
        catch { return false; }
    }

    private bool HasDown(int x, int y)
    {
        try
        { return (_layout[x, y - 1] == 0) ? false : true; }
        catch { return false; }
    }
    private bool HasLeft(int x, int y)
    {
        try
        {
            return (_layout[x - 1, y] == 0) ? false : true;
        }
        catch
        {
            return false;
        }
    }



    public Vector2 GetCubySpawnPos()
    {
        return _cubySpawnPos;
    }

    public List<GameObject> GetRooms()
    {
        return _rooms;
    }

    public void AddItemRooms(int amount)
    {
        for (int i = 0; i < amount;)
        {
            int rindex = Random.Range(0, _rooms.Count);

            var room = _rooms[rindex];

            var roomtype = room.GetComponent<RoomStats>().GetRoomType();

            if (roomtype != RoomType.SpecialRoom && roomtype != RoomType.SpawnRoom)
            {
                room.GetComponent<RoomStats>().SetRoomType(RoomType.SpecialRoom);
                ++i; //increase for loop index
            }
        }
    }

    public void AddSpawnroom()
    {
        bool searching = true;
        while (searching)
        {
            int rindex = Random.Range(0, _rooms.Count);
            var room = _rooms[rindex];
            var roomtype = room.GetComponent<RoomStats>().GetRoomType();
            if (roomtype != RoomType.SpecialRoom)
            {
                room.GetComponent<RoomStats>().SetRoomType(RoomType.SpawnRoom);
                _cubySpawnPos = room.transform.position;
                searching = false;
            }
        }
    }

    void AddRoomLayouts()
    {
        foreach (GameObject room in _rooms)
        {
            var roomtype = room.GetComponent<RoomStats>().GetRoomType();
            int rindex = 0;

            switch (roomtype)
            {
                case RoomType.SpecialRoom:
                    rindex = Random.Range(0, _itemRoomLayouts.Count);
                    Instantiate(_itemRoomLayouts[rindex], room.transform.position, Quaternion.identity);        
                    break;
                case RoomType.SpawnRoom:
                    rindex = Random.Range(0, _startRoomLayouts.Count);
                    Instantiate(_startRoomLayouts[rindex], room.transform.position, Quaternion.identity);
                    break;
            }

        }
    }

    public void Clear()
    {
        _rooms.Clear();
    }

}
