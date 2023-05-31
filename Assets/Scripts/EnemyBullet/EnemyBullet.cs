using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public float maxLength;
    public float lifeTime;
    public float damage;
    public Rigidbody2D rbGraphics;

    protected Rigidbody2D rb;
    protected float timePassed;
    protected bool canAffect;
    protected HashSet<Player> playerSet;
    public Enemy from;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        speed = 5;
        maxLength = 100;
        damage = 10;
        lifeTime = maxLength / speed;
        rb = GetComponent<Rigidbody2D>();


    }

    //DEFAULT: dies once pass lifetime
    protected virtual void Update()
    {
        rbGraphics.position = rb.position;
        timePassed += Time.deltaTime;
        if (timePassed > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    //DEFAULT: moves to the direction of rb.rotation
    protected virtual void FixedUpdate()
    {
        Vector2 velocity = new Vector2(speed * Mathf.Cos(rbGraphics.rotation * Mathf.Deg2Rad), speed * Mathf.Sin(rbGraphics.rotation * Mathf.Deg2Rad));
        rb.velocity = velocity;
    }

    //DEFAULT: Once hit: deals damage and dies
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Player":
                collision.gameObject.GetComponent<Player>().HitBy(this);
                Destroy(gameObject);
                break;
            default:
                break;
        }

    }
}
