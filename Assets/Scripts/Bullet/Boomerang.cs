using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Bullet
{
    public float accerelation;
    bool forward;
    public float maxSpeed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        accerelation = 8;
        forward = true;
        maxSpeed = 10;
        speed = maxSpeed;
        maxLength = 5;
        lifeTime = 1;
        rb = GetComponent<Rigidbody2D>();
        enemySet = new HashSet<Enemy>();
        damage = 20;
    }

    // Update is called once per frame
    void Update()
    {
        rbGraphics.position = rb.position;
        timePassed += Time.deltaTime;
        if (forward && timePassed > lifeTime)
        {
            forward = false;
            enemySet = new HashSet<Enemy>();
        }
    }

    void FixedUpdate()
    {
        
        if (forward)
        {
            speed -= accerelation * Time.fixedDeltaTime;
            Vector2 velocity = new Vector2(speed * Mathf.Cos(rbGraphics.rotation * Mathf.Deg2Rad), speed * Mathf.Sin(rbGraphics.rotation * Mathf.Deg2Rad));
            rb.velocity = velocity;
        }
        else if (!forward)
        {
            speed += accerelation * Time.fixedDeltaTime;
            Vector2 direction = from.GetComponent<Rigidbody2D>().position  - rb.position;
            direction.Normalize();
            rb.velocity = direction * speed;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (forward)
        {
            if (collision.gameObject.tag == "Wall")
            {
                rb.rotation += 180;
                forward = false;
                enemySet = new HashSet<Enemy>();
            }
        }
        else if (!forward)
        {
            if (collision.gameObject.GetComponent<Player>() == from)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy target = collision.gameObject.GetComponent<Enemy>();
            if (!enemySet.Contains(target))
            {
                enemySet.Add(target);
                target.HitBy(this);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
