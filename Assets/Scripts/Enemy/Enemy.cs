using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Reference reference;
    public GameObject enemyBulletPrefab;
    public Animator animator;
    public Rigidbody2D rbGraphics;

    
    public HealthBar healthBar;

    public Player target;
    public Rigidbody2D rb;
    public Rigidbody2D targetRb;

    public float maxHp;
    public float hp;
    public float movementSpeed;
    public float range;
    public float shootFrequency;
    public float cycleTime;
    

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
        target = reference.player;
        rb = GetComponent<Rigidbody2D>();
        targetRb = target.GetComponent<Rigidbody2D>();

        maxHp = 100;
        hp = maxHp;
        movementSpeed = 0;
        range = 0;
        shootFrequency = 3;
        cycleTime = Random.Range(0, 2);
    }

    //DEFAULT: updates HpBar and position rbGraphics
    protected virtual void Update()
    {
        UpdateHpBar();
        rbGraphics.transform.position = rb.transform.position;
    }

    //DEFAULT: aims rbGraphics to target, shoots once every shootFrequency
    protected virtual void FixedUpdate()
    {
        cycleTime += Time.fixedDeltaTime;
        
        target = reference.player;
        targetRb = target.GetComponent<Rigidbody2D>();

        Vector2 toTarget = targetRb.position - rb.position;
        rbGraphics.rotation = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg;

        if (cycleTime >= shootFrequency)
        {
            animator.SetBool("Shooting", true);
            cycleTime = 0;
        }
    }

    
    protected void UpdateHpBar()
    {
        healthBar.transform.position = transform.position + new Vector3(0, 0.5f);
        healthBar.SetBar(hp / maxHp);
        if (hp <= 0)
        {
            hp = 0;
            Destroy(gameObject);
            
        }
    }

    public void HitBy(Bullet bullet)
    {
        hp -= bullet.damage;
        if (hp <= 0)
        {
            hp = 0;
            Destroy(gameObject);
            
        }
    }

    // just a single bullet
    public virtual void Shoot(float angle)
    {
        //Debug.Log("Shoot function");
        GameObject newEnemyBullet = Instantiate(enemyBulletPrefab);
        newEnemyBullet.transform.position = transform.position;
        newEnemyBullet.GetComponent<EnemyBullet>().rbGraphics.rotation = angle;

        //set from
        newEnemyBullet.GetComponent<EnemyBullet>().from = gameObject.GetComponent<Enemy>();
    }
}
