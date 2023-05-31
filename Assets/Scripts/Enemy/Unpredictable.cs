using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unpredictable : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        target = reference.player;
        rb = GetComponent<Rigidbody2D>();
        targetRb = target.GetComponent<Rigidbody2D>();

        maxHp = 100;
        hp = maxHp;
        movementSpeed = 0;
        range = 0;
        shootFrequency = 4;
        cycleTime = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        
    }

    private void FixedUpdate()
    {
        cycleTime += Time.fixedDeltaTime;

        
        targetRb = target.GetComponent<Rigidbody2D>();
        Vector2 toTarget = targetRb.position - rb.position;
        rbGraphics.rotation = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg;

        if (cycleTime > shootFrequency)
        {
            animator.SetBool("Shooting", true);
            cycleTime = Random.Range(0,2); //makes it unpredictable
        }
    }
    public override void Shoot(float angle)
    {
        base.Shoot(angle);
    }
}
