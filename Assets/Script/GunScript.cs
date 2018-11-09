﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    [SerializeField] private float _gundamage = 1.0f;


    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _gunpoint;
    [SerializeField] private bool _IsAutomatic = true;
    [SerializeField] private float _firerate = 0.25f;

    private float _Cooldown = 0.0f;

    private CameraShake _shake;
    // Use this for initialization
	void Start () {
        _shake = CameraShake.GetInstance();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!_IsAutomatic)
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleShooting();

                _shake.Shake();
            }
        }
        else
        {
            _Cooldown -= Time.deltaTime;
            if (Input.GetMouseButton(0))
            {
                if(_Cooldown <= 0.0f)
                {
                    _Cooldown = _firerate;
                    HandleShooting();
                    _shake.Shake();
                }
            }
                //handle cooldown
        }
	}

    public float CalculateAngle()
    {
        Vector2 mouseworldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pos = transform.position;
        Vector2 dp = mouseworldpos - pos;

        float angle = Mathf.Atan2(dp.y, dp.x);
        return angle;
    }

    public Quaternion CalculateRotation(float angle)
    {
        float spriteangle = angle * Mathf.Rad2Deg;

        return Quaternion.Euler(new Vector3(0, 0, spriteangle));
    }

    public void SpawnBullet(float angle)
    {
        Quaternion quat = CalculateRotation(angle);
        GameObject bullet = Instantiate(_bullet, _gunpoint.transform.position, quat);
        bullet.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        bullet.GetComponent<BulletScript>().SetDirection(direction.x, direction.y);
        bullet.GetComponent<BulletScript>().SetDamage(_gundamage);
    }

    public virtual void HandleShooting()
    {
        float angle = CalculateAngle();
        SpawnBullet(angle);
    }

    
    
}
