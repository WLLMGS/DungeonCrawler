using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

	[SerializeField] private List<GameObject> _effects = new List<GameObject>();
	
	private static EffectManager _instance = null;

	void Awake()
	{
		if(_instance == null) _instance = this;
	}

	public static EffectManager GetInstance()
	{
		return _instance;
	}

	public void SpawnEffect(int index, Vector3 location, int scale = 1)
	{
		if(index < _effects.Count)
		{
			GameObject inst = Instantiate(_effects[index], location, Quaternion.identity);
			inst.transform.localScale = new Vector3(scale, scale, scale);
		}
	} 
}
