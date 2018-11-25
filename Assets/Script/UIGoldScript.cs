using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;


public class UIGoldScript : MonoBehaviour {


	private Text _textfield;
	private PlayerStats _stats;
	// Use this for initialization
	void Start () {
		_textfield = GetComponentInChildren<Text>();
		_stats = PlayerStats.GetInstance();

		Assert.IsNotNull(_textfield, "no text component found for gold coint");
	}
	
	// Update is called once per frame
	void Update () {
		UpdateGoldCounter();
	}

	void UpdateGoldCounter()
	{
		int gold = _stats.Gold;
		_textfield.text = gold.ToString();
	}
}
