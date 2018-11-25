using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : MonoBehaviour
{

    private bool _canPickUp = true;
    [SerializeField] protected float _manaCost = 20.0f;
    [SerializeField] protected bool _IsSkill = false;

    private bool _isHovering = false;
    private GameObject _player;

    public bool CanPickUp
    {
        get
        {
            return _canPickUp;
        }
        set
        {
            _canPickUp = value;
        }
    }

    void Start()
    {
        _player = GameObject.Find("Cuby");
    }

    void Update()
    {
        if (_isHovering)
        {
            if (_IsSkill)
            {

            }
            else
            {
                PowerUp(_player);
                Destroy(gameObject);
            }
        }
    }

    virtual public void PowerUp(GameObject player) { }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && _canPickUp)
        {
            _isHovering = true;
            // 	PowerUp(col.gameObject); //add power up to player
            // 	Destroy(gameObject); //destroy the power up
            //
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" && _canPickUp)
        {
            _isHovering = true;
            // PowerUp(col.gameObject); //add power up to player
            // Destroy(gameObject); //destroy the power up
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _isHovering = false;
        }
    }
    public void CheckForAbilities(GameObject player)
    {
        RightClickAbility comp = player.GetComponent<RightClickAbility>();
        if (comp != null) Destroy(comp);
    }
}
