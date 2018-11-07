using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    [SerializeField] private float _gundamage = 1.0f;


    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _gunpoint;
    [SerializeField] private CameraShake _shake;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleShooting();
	}

    void HandleShooting()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //need angle first
            Vector2 mouseworldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 pos = transform.position;
            Vector2 dp =  mouseworldpos - pos;

            float angle = Mathf.Atan2(dp.y, dp.x);
            float spriteangle = angle * Mathf.Rad2Deg;
            
            Quaternion quat = Quaternion.Euler(new Vector3(0, 0, spriteangle));


            GameObject bullet = Instantiate(_bullet, _gunpoint.transform.position, quat);
            bullet.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));


            bullet.GetComponent<BulletScript>().SetDirection(direction.x, direction.y);
            bullet.GetComponent<BulletScript>().SetDamage(_gundamage);

            _shake.Shake();
        }
    }

    
    
}
