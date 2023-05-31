using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeonardoGraphics : PlayerGraphics
{
    Leonardo leonardoScript;
    public float initialAngle;
    public int bulletNumber;

    // Start is called before the first frame update
    void Start()
    {
        leonardoScript = GetComponentInParent<Leonardo>();
        bulletNumber = 0;
        initialAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //for animator, just links to Lampy.Shoot()
    public override void Shoot()
    {
        if (bulletNumber == 0)
        {
            initialAngle = leonardoScript.aimAngle;
        }
        leonardoScript.Shoot(initialAngle + (2 - bulletNumber) * 10);
        bulletNumber += 1;
        Debug.Log("blade");
    }
}
