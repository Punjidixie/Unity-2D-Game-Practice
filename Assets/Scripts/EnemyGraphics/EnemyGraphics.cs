using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGraphics : MonoBehaviour
{
    Enemy enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        enemyScript = GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //for animator, just links to Player.Shoot()
    public virtual void Shoot()
    {
        enemyScript.Shoot(enemyScript.rbGraphics.rotation);
        
    }
}
