using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkillPortraitManager : MonoBehaviour {

	[SerializeField] private Image _portrait1;
	[SerializeField] private Image _portrait2;
	
	private static UISkillPortraitManager _instance = null;

	void Awake()
	{
		if(_instance == null) _instance = this;
	}
	public static UISkillPortraitManager GetInstance()
	{
		return _instance;
	}

	public void AssignFirstSkillPortrait(Sprite sprite)
	{
		_portrait1.gameObject.SetActive(true);
		_portrait1.sprite = sprite;
	}
	public void AssignSecondSkillPortrait(Sprite sprite)
	{
		_portrait2.gameObject.SetActive(true);
		_portrait2.sprite = sprite;
	}
}
