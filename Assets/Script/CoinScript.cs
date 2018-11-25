using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private float _maxforce = 12.0f;
    private float _threshold = 0.1f;
    private GameObject _player;
    private Rigidbody2D _rigid;
    // Use this for initialization
    void Start()
    {
        _player = GameObject.Find("Cuby");
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _maxforce * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            PlayerStats.GetInstance().Gold += 1;
            Destroy(gameObject);
        }
    }
}
