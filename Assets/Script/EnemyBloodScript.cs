 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBloodScript : MonoBehaviour {

    [SerializeField] List<GameObject> _blood;

    private float _range = 0.5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnBlood()
    {
        Vector3 pos = new Vector3();
        pos.x = transform.position.x + Random.Range(-_range, _range);
        pos.y = transform.position.y + Random.Range(-_range, _range);
        pos.z = 2;

        Vector3 localscale = new Vector3();
        localscale.x = Random.Range(0.5f, 2.0f);
        localscale.y = localscale.x;
        localscale.z = 1;

        float angle = Random.Range(0, 360.0f);
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));


        int index = Random.Range(0, _blood.Count);

        var obj = Instantiate(_blood[index], pos, rotation);
        obj.transform.localScale = localscale;
    }
}
