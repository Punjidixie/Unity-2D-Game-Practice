using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyGraphics : EnemyGraphics
{
    WalkingEnemy walkingEnemyScript;

    // Start is called before the first frame update
    void Start()
    {
        walkingEnemyScript = GetComponentInParent<WalkingEnemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public override void Shoot()
    {
        walkingEnemyScript.Shoot(walkingEnemyScript.rbGraphics.rotation);

    }
}