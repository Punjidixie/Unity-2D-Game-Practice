using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
        maxLength = 4;
        damage = 40;
        lifeTime = maxLength / speed;
        rb = GetComponent<Rigidbody2D>();
        enemySet = new HashSet<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        rbGraphics.position = rb.position;
        timePassed += Time.deltaTime;
        if (timePassed > lifeTime)
        {
            from.rb.position = rb.position;
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        base.FixedUpdate();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                from.rb.position = rb.position;
                Destroy(gameObject);
                break;
            case "Enemy":
                Enemy target = collision.gameObject.GetComponent<Enemy>();
                if (!enemySet.Contains(target))
                {
                    enemySet.Add(target);
                    target.HitBy(this);
                }
                break;
            default:
                break;
        }
    }
}
