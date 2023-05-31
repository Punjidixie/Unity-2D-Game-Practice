using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lampy : Player
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        movementSpeed = 2.5f;
        maxHp = 200;
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Shoot(float angle)
    {
        base.Shoot(angle);
    }
}
