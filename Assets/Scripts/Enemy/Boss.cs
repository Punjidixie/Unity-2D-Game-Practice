using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public GameObject blackHolePrefab;
    public GameObject bossBulletPrefab;
    public GameObject trapPrefab;
    public GameObject targetLinePrefab;
    public GameObject meteorPrefab;

    public float abilityPeriod;
    
    // Start is called before the first frame update
    void Start()
    {
        target = reference.player;
        rb = GetComponent<Rigidbody2D>();
        targetRb = target.GetComponent<Rigidbody2D>();

        maxHp = 1000;
        hp = maxHp;
        cycleTime = 0;
        abilityPeriod = 3;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHpBar();

        cycleTime += Time.deltaTime;
        if (cycleTime > abilityPeriod)
        {
            float rand = Random.value;
            if (rand < 1f / 4f)
            {
                animator.SetBool("ShootFollow", true);
                abilityPeriod = Random.Range(7f, 10f);
            }
            else if (rand < 2f / 4f)
            {
                animator.SetBool("TrapsPlayer", true);
                abilityPeriod = Random.Range(0.5f, 4f);
            }
            else if (rand < 3f / 4f)
            {
                animator.SetBool("BlackHoleNSprays", true);
                abilityPeriod = Random.Range(10f, 13f);
            }
            else
            {
                animator.SetBool("SummonsMeteor", true);
                abilityPeriod = Random.Range(6f, 9f);
            }
            cycleTime = 0;
        }
    }
    private void FixedUpdate()
    {
        target = reference.player;
        targetRb = target.GetComponent<Rigidbody2D>();
        rbGraphics.position = rb.position;
    }
}
