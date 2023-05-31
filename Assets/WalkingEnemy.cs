using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        maxHp = 100;
        hp = maxHp;
        movementSpeed = 0.7f;
        range = 3;
        shootFrequency = 1;
        cycleTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    private void FixedUpdate()
    {
        
    }

    public override void Shoot(float angle)
    {
        base.Shoot(angle);
    }
}
