using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningEnemy : Enemy
{

    private float rotationRate;
    // Start is called before the first frame update
    void Start()
    {
        target = reference.player;
        rb = GetComponent<Rigidbody2D>();
        targetRb = target.GetComponent<Rigidbody2D>();

        maxHp = 100;
        hp = maxHp;
        movementSpeed = 0;
        range = 0;
        shootFrequency = 4;
        cycleTime = Random.Range(0, 2);

        rotationRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        


    }

    private void FixedUpdate()
    {
        cycleTime += Time.fixedDeltaTime;

        targetRb = target.GetComponent<Rigidbody2D>();

        rbGraphics.rotation += rotationRate * Time.fixedDeltaTime;

        if (cycleTime > shootFrequency)
        {
            animator.SetBool("Shooting", true);
            cycleTime = 0;
        }
    }
    public override void Shoot(float angle)
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject newEnemyBullet = Instantiate(enemyBulletPrefab);
            newEnemyBullet.transform.position = transform.position;
            newEnemyBullet.GetComponent<EnemyBullet>().rbGraphics.rotation = angle + 90 * i;

            //set from
            newEnemyBullet.GetComponent<EnemyBullet>().from = gameObject.GetComponent<Enemy>();
        }
    }
}
