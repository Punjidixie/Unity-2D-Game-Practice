using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : EnemyBullet
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        speed = 15;
        maxLength = 100;
        lifeTime = maxLength / speed;
        damage = 40;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            
            case "Player":
                collision.gameObject.GetComponent<Player>().HitBy(this);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
