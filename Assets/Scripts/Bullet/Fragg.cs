using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragg : Bullet
{
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        maxLength = 5;
        damage = 10;
        lifeTime = maxLength / speed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    private void FixedUpdate()
    {
        base.FixedUpdate();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
