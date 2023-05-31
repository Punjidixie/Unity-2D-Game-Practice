using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float maxLength;
    public float lifeTime;
    public float damage;
    public Rigidbody2D rbGraphics;

    protected Rigidbody2D rb;
    protected float timePassed;
    protected bool canAffect;
    protected HashSet<Enemy> enemySet;
    public Player from;

    public AudioClip audioClip1;
    public AudioClip audioClip2;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        maxLength = 5;
        damage = 10;
        lifeTime = maxLength / speed;
        rb = GetComponent<Rigidbody2D>();
        enemySet = new HashSet<Enemy>();
        
    }

    // Update is called once per frame
    protected void Update()
    {
        rbGraphics.position = rb.position;
        timePassed += Time.deltaTime;
        if (timePassed > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    protected void FixedUpdate()
    {
        rbGraphics.position = rb.position;
        
        Vector2 velocity = new Vector2(speed * Mathf.Cos(rbGraphics.rotation * Mathf.Deg2Rad), speed * Mathf.Sin(rbGraphics.rotation * Mathf.Deg2Rad));
        rb.velocity = velocity;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Enemy":
                collision.gameObject.GetComponent<Enemy>().HitBy(this);
                Destroy(gameObject);
                break;
            default:
                break;
        }
        
    }
}
