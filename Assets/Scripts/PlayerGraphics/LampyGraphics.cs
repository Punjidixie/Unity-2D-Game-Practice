using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampyGraphics : PlayerGraphics
{
    Lampy lampyScript;

    // Start is called before the first frame update
    void Start()
    {
        lampyScript = GetComponentInParent<Lampy>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //for animator, just links to Lampy.Shoot()
    public override void Shoot()
    {
        lampyScript.Shoot(lampyScript.aimAngle);
        Debug.Log("SHOOOOOOOT");
    }
}
