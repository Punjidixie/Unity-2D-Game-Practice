using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonEnemy : Enemy
{
    public Poison poison;
    Rigidbody2D poisonRb;

    // Start is called before the first frame update
    void Start()
    {
        target = reference.player;
        rb = GetComponent<Rigidbody2D>();
        targetRb = target.GetComponent<Rigidbody2D>();
        poisonRb = poison.gameObject.GetComponent<Rigidbody2D>();

        maxHp = 100;
        hp = maxHp;
        movementSpeed = 0.5f;
        range = 1.4f;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        

        
    }

    void FixedUpdate()
    {
        
        poisonRb.position = rb.position;
        targetRb = target.GetComponent<Rigidbody2D>();

        if ((targetRb.position - rb.position).magnitude > range)
        {
            rb.velocity = (targetRb.position - rb.position).normalized * movementSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
