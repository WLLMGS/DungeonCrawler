using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosionScript : MonoBehaviour
{

    [SerializeField] private GameObject _explosionPiece;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Explode()
    {
        for (int i = 0; i < 8; ++i)
        {
            Vector3 position = transform.position;
            position.x += Random.Range(-0.5f, 0.5f);
            position.y += Random.Range(-0.5f, 0.5f);
            position.z = 1;

            GameObject piece = Instantiate(_explosionPiece, position, Quaternion.identity);

            Vector2 force = Vector2.zero;
            force.x = Random.Range(-5, 5);
            force.y = Random.Range(-5, 5);

           piece.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);

        }
    }
}
