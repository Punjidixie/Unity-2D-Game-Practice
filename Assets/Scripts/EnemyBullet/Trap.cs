using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : EnemyBullet
{
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 5;
        timePassed = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rbGraphics.position = rb.position;
        timePassed += Time.deltaTime;
        if (timePassed > lifeTime)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        
    }
}
