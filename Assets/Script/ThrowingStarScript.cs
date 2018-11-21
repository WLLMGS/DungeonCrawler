using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingStarScript : MonoBehaviour
{

    [SerializeField] private bool _doDestroyOnImpact = false;
    private PlayerStats _stats;
    void Start()
    {
        _stats = PlayerStats.GetInstance();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 90.0f * Time.deltaTime));
        if (transform.parent != null) transform.RotateAround(transform.parent.position, new Vector3(0, 0, 1), 90.0f * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyBloodScript>().SpawnBlood();
            col.gameObject.GetComponent<EnemyHealth>().AddHealth(-_stats.GetDamage() * 5.0f);
            CameraShake.GetInstance().Shake();

            if (_doDestroyOnImpact) Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyBloodScript>().SpawnBlood();
            col.gameObject.GetComponent<EnemyHealth>().AddHealth(-_stats.GetDamage() * 5.0f);
            CameraShake.GetInstance().Shake();
		}


    }
    public void SetDoDestroyOnImpact(bool b)
    {
        _doDestroyOnImpact = b;
    }
}
