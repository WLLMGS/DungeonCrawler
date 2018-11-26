using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemDescriptionScript : MonoBehaviour
{

    private static ItemDescriptionScript _instance = null;

	private Text _description;
    private float _activeTime = 2.0f;
    private float _timer = 0.0f;

	public static ItemDescriptionScript Instance
	{
		get
		{
			return _instance;
		}
	}


    void Awake()
    {
        if (_instance == null) _instance = this;
    }

	void Start()
	{
		_description = GetComponent<Text>();
	}

	void Update()
	{
		_timer -= Time.deltaTime;

		if(_timer <= 0.0f)
		{
			gameObject.SetActive(false);
		}

		Mathf.Clamp(_timer, -1.0f,1000.0f);
	}

    public void Activate(string description)
    {
		Debug.Log("description activated");
        gameObject.SetActive(true);
		_timer = _activeTime;
		_description.text = description;
    }
}
