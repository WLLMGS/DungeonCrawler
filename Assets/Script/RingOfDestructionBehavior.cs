using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfDestructionBehavior : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().AddHealth(-PlayerStats.GetInstance().Damage * 7.5f);
        }
    }
}
