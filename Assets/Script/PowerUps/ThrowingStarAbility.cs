using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingStarAbility : RightClickAbility
{
    [SerializeField] private GameObject _throwingstar;
    public void SetThrowingStar(GameObject obj)
    {
		_throwingstar = obj;
    }
    public override void DoAbility()
    {
        GameObject _player = GameObject.Find("Cuby");

        GameObject inst = Instantiate(_throwingstar, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
        inst.GetComponent<ThrowingStarScript>().SetDoDestroyOnImpact(true);
        inst.transform.parent = _player.transform;

        inst = Instantiate(_throwingstar, transform.position + new Vector3(0, -1.5f, 0), Quaternion.identity);
        inst.transform.parent = _player.transform;
        inst.GetComponent<ThrowingStarScript>().SetDoDestroyOnImpact(true);

        inst = Instantiate(_throwingstar, transform.position + new Vector3(1.5f, 0, 0), Quaternion.identity);
        inst.transform.parent = _player.transform;
        inst.GetComponent<ThrowingStarScript>().SetDoDestroyOnImpact(true);

        inst = Instantiate(_throwingstar, transform.position + new Vector3(-1.5f, 0, 0), Quaternion.identity);
        inst.transform.parent = _player.transform;
        inst.GetComponent<ThrowingStarScript>().SetDoDestroyOnImpact(true);

    }
}
