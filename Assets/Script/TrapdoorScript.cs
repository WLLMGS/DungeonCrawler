using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapdoorScript : MonoBehaviour {

	private bool _isHovering = false;
	[SerializeField] private GameObject _label;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.E) && _isHovering)
		{
			CubyGameManager.GetInstance().AdvanceLevel();
			Destroy(gameObject);
		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			_isHovering = true;
			_label.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			_isHovering = false;
			_label.SetActive(false);
		}
	}
}
