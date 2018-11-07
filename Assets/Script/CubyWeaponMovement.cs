using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubyWeaponMovement : MonoBehaviour
{

    [SerializeField] private GameObject _weapon;
    [SerializeField] private bool _doFlip = false;

    // Use this for initialization
    void Start()
    {
        _weapon = gameObject.transform.Find("Weapon").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
    }

    void HandleRotation()
    {
        Vector2 screenpos = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 mousepos = Input.mousePosition;

        Vector2 d = screenpos - mousepos;

        float angle = Mathf.Atan2(d.y, d.x);
        angle *= Mathf.Rad2Deg;
        angle += 180.0f;
        if (_doFlip)
        {
            if (angle > 90.0f && angle < 270.0f)
            {
                _weapon.transform.localScale = new Vector3(1, -1, 1);
            }
            else _weapon.transform.localScale = new Vector3(1, 1, 1);
        }

        _weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    

}
