using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningEnemyGraphics : EnemyGraphics
{
    SpinningEnemy spinningEnemyScript;

    // Start is called before the first frame update
    void Start()
    {
        spinningEnemyScript = GetComponentInParent<SpinningEnemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public override void Shoot()
    {
        spinningEnemyScript.Shoot(spinningEnemyScript.rbGraphics.rotation);

    }
}