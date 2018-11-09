using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosionScript : MonoBehaviour
{

    [SerializeField] private GameObject _explosionPiece;

    private float _force = 2;
    

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
            force.x = Random.Range(-_force, _force);
            force.y = Random.Range(-_force, _force);

           piece.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);

        }
    }
}
