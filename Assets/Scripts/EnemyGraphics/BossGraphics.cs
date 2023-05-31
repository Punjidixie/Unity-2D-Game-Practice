using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGraphics : EnemyGraphics
{
    Boss bossScript;
    // Start is called before the first frame update
    void Start()
    {
        bossScript = GetComponentInParent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropBlackHole()
    {

        GameObject blackHole = Instantiate(bossScript.blackHolePrefab);
        blackHole.transform.position = transform.position;
    }

    public void ShootThreeBullets()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject bossBullet = Instantiate(bossScript.bossBulletPrefab);
            bossBullet.transform.position = transform.position;
            bossBullet.GetComponent<BossBullet>().rbGraphics.rotation = -90 + (i - 1) * 25;
            
            bossBullet.GetComponent<EnemyBullet>().from = gameObject.GetComponentInParent<Boss>();
        } 
    }

    public void ShootOneBulletFollow()
    {
        GameObject bossBullet = Instantiate(bossScript.bossBulletPrefab);
        bossBullet.transform.position = transform.position;
        bossBullet.GetComponent<BossBullet>().rbGraphics.rotation = bossScript.rbGraphics.rotation;

        bossBullet.GetComponent<EnemyBullet>().from = gameObject.GetComponentInParent<Boss>();
    }

    public void Trap()
    {
        GameObject trap = Instantiate(bossScript.trapPrefab);
        trap.transform.position = bossScript.target.transform.position;
    }

    
}
