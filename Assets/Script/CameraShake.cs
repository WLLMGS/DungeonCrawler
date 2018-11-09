using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	[SerializeField] private Animator _anim;

    private static CameraShake _instance = null;

    private void Awake()
    {
        if (_instance == null) _instance = this;
    }

    public static CameraShake GetInstance()
    {
        return _instance;
    }

    public void Shake()
	{
		_anim.SetTrigger("Shake");
	}
}
