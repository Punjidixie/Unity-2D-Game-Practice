using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : EnemyBullet
{
    float hitFrequency;
    float cycleTime;
    // Start is called before the first frame update
    void Start()
    {
        canAffect = false;
        cycleTime = 0;
        hitFrequency = 0.5f;
        damage = 10;
        playerSet = new HashSet<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rbGraphics.position = rb.position;
    }

    private void FixedUpdate()
    {
        cycleTime += Time.fixedDeltaTime;
        if (cycleTime > hitFrequency)
        {
            playerSet.Clear();
            cycleTime = 0;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player target = collision.gameObject.GetComponent<Player>();
            if (!playerSet.Contains(target))
            {
                target.HitBy(this);
                playerSet.Add(target);

            }
        }
    }
}
