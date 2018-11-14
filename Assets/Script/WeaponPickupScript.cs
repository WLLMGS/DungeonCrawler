using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupScript : MonoBehaviour {

    private GameObject _player;

    bool _isPickedUp = false;
    CubyWeaponMovement _weaponMovement;
    GunScript _gun;

    bool _canPickupAgain = true;

    private void Start()
    {
        _player = GameObject.Find("Cuby");

        //get the comps
        _weaponMovement = GetComponent<CubyWeaponMovement>();
        _gun = GetComponentInChildren<GunScript>();
        //disable them until picked up
        _weaponMovement.enabled = false;
        _gun.enabled = false;
     }
    
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)
        && _isPickedUp)
        {
            Debug.Log("Drop weapon");
            //notify cuby that he doesnt have a weapon anymore
            GameObject.Find("Cuby").GetComponent<CubyWeaponTracker>().SetHasWeapon(false);

            //disconnect from parent
            transform.parent = null;
            _gun.enabled = false;
            _weaponMovement.enabled = false;
            GetComponent<BoxCollider2D>().enabled = true;
            
            //reset weapon pickup
            StartCoroutine(ReEnableCollider());
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"
        && _canPickupAgain
        && !_player.GetComponent<CubyWeaponTracker>().HasWeapon()
        )
        {
            _canPickupAgain = false;

            _isPickedUp = true;
            //enable aiming & shooting
            _weaponMovement.enabled = true;
            _gun.enabled = true;

            //set to correct position & parent
            transform.parent = col.gameObject.transform;
            transform.position = col.gameObject.transform.Find("WeaponSocket").position;

            //disable the trigger so it can't be picked up anymore
            GetComponent<BoxCollider2D>().enabled = false;

            //notify weapon tracker that cuby has a weapon
            col.gameObject.GetComponent<CubyWeaponTracker>().SetHasWeapon(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        _canPickupAgain = true;
    }

    IEnumerator ReEnableCollider()
    {
        yield return new WaitForSeconds(5);
        GetComponent<BoxCollider2D>().enabled = true;
        _canPickupAgain = true;
        Debug.Log("Can Pick Up Again");
    }
}
