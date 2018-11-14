using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour {

        [SerializeField] private Texture2D _texture;

	// Use this for initialization
	void Start () {
                Cursor.SetCursor(_texture, new Vector2(32,32), CursorMode.Auto);
        }
	
	// Update is called once per frame
// 	void Update () {
//         Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//         pos.z = -50;
//         transform.position = pos;
//     }
}
