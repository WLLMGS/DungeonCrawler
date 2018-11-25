using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPickupBase : MonoBehaviour
{

    [SerializeField] private Sprite _skillImage;
    [SerializeField] protected float _manaCost = 25.0f;

    private GameObject _keys;
    private bool _canPickUp = true;
    private bool _isHovering = false;
    private GameObject _player = null;
    private bool _IsPrimarySkill = false;
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
        _keys = gameObject.transform.Find("AssignKeys").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isHovering)
        {
            //display labels
            //check for keys
            //if key is pressed add powerup to correct 

            if (Input.GetKeyDown(KeyCode.E))
            {
                RemoveExistingAbilities(true); //check for pre existing primary abilities
                AddSkill(_player, true); //add skill to player
                UISkillPortraitManager.GetInstance().AssignFirstSkillPortrait(_skillImage); //add portrait to UI
                Destroy(gameObject); //destroy the power up obj

            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                RemoveExistingAbilities(false); //check for pre existing secondary abilities
                AddSkill(_player, false); //add skill to player
                UISkillPortraitManager.GetInstance().AssignSecondSkillPortrait(_skillImage); //add portait to UI
                Destroy(gameObject); //destroy the power up obj
            }
        }
    }

    public virtual void AddSkill(GameObject player, bool isPrimarySkill) { }

    private void RemoveExistingAbilities(bool primary)
    {
        RightClickAbility[] abs = _player.GetComponents<RightClickAbility>();
        foreach (RightClickAbility a in abs)
        {
            if (a.IsPrimarySkill == primary)
            {
                Destroy(a);
                break;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && _canPickUp)
        {
            _isHovering = true;
            _keys.SetActive(true); //show key labels
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && _canPickUp)
        {
            _isHovering = true;
            _keys.SetActive(true); //show key labels
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _isHovering = false;
            _keys.SetActive(false); //hide key labels
        }
    }
}
