using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManaBarScript : MonoBehaviour {

	private Slider _slider;
	private PlayerStats _stats;

	// Use this for initialization
	void Start () {
		_stats = PlayerStats.GetInstance();
		_slider = GetComponent<Slider>();	
	}
	
	// Update is called once per frame
	void Update () {
		CalculateManaFill();
	}

	void CalculateManaFill()
	{
		float currentMana = _stats.GetCurrentMana();
		float maxMana = _stats.GetMaxMana();
		float ratio = currentMana / maxMana;

		_slider.value = ratio;
	}
}
