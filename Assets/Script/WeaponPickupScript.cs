using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupScript : MonoBehaviour {

    bool _isPickedUp = false;
    CubyWeaponMovement _weaponMovement;
    GunScript _gun;

    private void Start()
    {
        //get the comps
        _weaponMovement = GetComponent<CubyWeaponMovement>();
        _gun = GetComponentInChildren<GunScript>();
        //disable them until picked up
        _weaponMovement.enabled = false;
        _gun.enabled = false;
     }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _isPickedUp = true;
            //enable aiming & shooting
            _weaponMovement.enabled = true;
            _gun.enabled = true;

            //set to correct position & parent
            transform.parent = collision.gameObject.transform;
            transform.position = collision.gameObject.transform.Find("WeaponSocket").position;

            //disable the trigger so it can't be picked up anymore
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
