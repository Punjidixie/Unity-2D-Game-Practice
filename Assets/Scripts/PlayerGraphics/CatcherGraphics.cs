using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatcherGraphics : PlayerGraphics
{
    Catcher catcherScript;

    // Start is called before the first frame update
    void Start()
    {
        catcherScript = GetComponentInParent<Catcher>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //for animator, just links to Lampy.Shoot()
    public override void Shoot()
    {
        catcherScript.Shoot(catcherScript.aimAngle);
        Debug.Log("SHOOOOOOOT");
    }
}
