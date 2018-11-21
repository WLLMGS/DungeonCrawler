using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingStarPowerUp : PowerUpBase
{
    [SerializeField] private GameObject _throwingStar;

    public override void PowerUp(GameObject player)
    {
        GameObject obj = Instantiate(_throwingStar, player.transform.position + new Vector3(1.5f, 0, 0), Quaternion.identity);
        obj.transform.parent = player.transform;
    }
}
