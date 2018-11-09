﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
        Cursor.visible = false;	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = -50;
        transform.position = pos;
    }
}
