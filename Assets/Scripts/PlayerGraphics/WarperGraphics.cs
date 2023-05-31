using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarperGraphics : PlayerGraphics
{
    Warper warperScript;

    // Start is called before the first frame update
    void Start()
    {
        warperScript = GetComponentInParent<Warper>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //for animator, just links to Warper.Shoot()
    public override void Shoot()
    {
        warperScript.Shoot(warperScript.aimAngle);
        Debug.Log("SHOOOOOOOT");
    }
}
