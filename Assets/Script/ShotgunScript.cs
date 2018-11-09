using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : GunScript {
    
    public override void HandleShooting()
    {
        float angle = CalculateAngle();
        float angle2 = angle + Mathf.Deg2Rad * 10.0f;
        float angle3 = angle - Mathf.Deg2Rad * 10.0f;

        SpawnBullet(angle);
        SpawnBullet(angle2);
        SpawnBullet(angle3);

    }


}
