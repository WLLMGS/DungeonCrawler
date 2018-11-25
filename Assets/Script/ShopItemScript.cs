using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemScript : MonoBehaviour
{

    private int _cost = 10;
    private PowerUpBase _linkedItem;
    private SkillPickupBase _linkedSkill;

    private GameObject _shoplabel;
    public int Cost
    {
        get
        {
            return _cost;
        }
        set
        {
            _cost = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        //check if skill or if passive item

        _linkedItem = GetComponent<PowerUpBase>(); //get component
        if (_linkedItem != null)
        {
            _linkedItem.CanPickUp = false; // set pickup to false
            _shoplabel = _linkedItem.gameObject.transform.Find("ShopLabel").gameObject; // get shop label
        }
        else
        {
            _linkedSkill = GetComponent<SkillPickupBase>();
            _linkedSkill.CanPickUp = false;
            _shoplabel = _linkedSkill.gameObject.transform.Find("ShopLabel").gameObject; // get shop label
        }


        _shoplabel.SetActive(true); //set shop label visible
                                    //set shop label to cost
        _shoplabel.GetComponentInChildren<Text>().text = _cost.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            int gold = PlayerStats.GetInstance().Gold;

            if (gold >= Cost)
            {

                //check if dealing with skill or passive item
                if(_linkedItem != null && _linkedItem.CanPickUp == false)
                {
                    _linkedItem.CanPickUp = true;
                }
                else if(_linkedSkill != null && _linkedSkill.CanPickUp == false)
                {
                    _linkedSkill.CanPickUp = true;
                }

                 PlayerStats.GetInstance().Gold -= Cost;
                _shoplabel.SetActive(false);
            }
        }
    }
}
