using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpredictableGraphics : EnemyGraphics
{
    Unpredictable unpredictableScript;

    // Start is called before the first frame update
    void Start()
    {
        unpredictableScript = GetComponentInParent<Unpredictable>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public override void Shoot()
    {
        unpredictableScript.Shoot(unpredictableScript.rbGraphics.rotation);
        
    }
}