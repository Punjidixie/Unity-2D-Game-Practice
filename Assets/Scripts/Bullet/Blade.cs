using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : Bullet
{
    public float initialDamage;
    public float damageDecreasingRate;
    public float expansionRate;
    // Start is called before the first frame update
    void Start()
    {
        initialDamage = 18;
        speed = 10;
        maxLength = 6;
        damage = initialDamage;
        lifeTime = maxLength / speed;
        expansionRate = 0.5f / lifeTime;
        damageDecreasingRate = 12f / lifeTime;
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    void FixedUpdate()
    {
        base.FixedUpdate();
        damage -= damageDecreasingRate * Time.fixedDeltaTime;
        GetComponent<BoxCollider2D>().size = GetComponent<BoxCollider2D>().size + new Vector2(expansionRate, expansionRate) * Time.fixedDeltaTime;
        rbGraphics.gameObject.transform.localScale = new Vector3(rbGraphics.gameObject.transform.localScale.x + expansionRate * Time.fixedDeltaTime, rbGraphics.gameObject.transform.localScale.y + expansionRate * Time.fixedDeltaTime, 1);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
