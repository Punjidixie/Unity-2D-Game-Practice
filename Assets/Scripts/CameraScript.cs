using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Reference reference;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = reference.player;
        transform.position = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {

        player = reference.player;
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, transform.position.z);

        //Vector2 lerpPosition = Vector2.zero;
        //if (reference.joystick.Horizontal == 0 && reference.joystick.Vertical == 0 && Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        //{
        //    lerpPosition = Vector2.zero;
        //}
        //else
        //{

        //    if (reference.joystick.Horizontal != 0 || reference.joystick.Vertical != 0)
        //    {
        //        lerpPosition = new Vector2(reference.joystick.Horizontal, reference.joystick.Vertical).normalized * 2;
        //    }
        //    else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        //    {
        //        lerpPosition = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * 2;
        //    }

        //}

        //transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, 0) + new Vector3(lerpPosition.x, lerpPosition.y, -10), Time.deltaTime * (Time.timeScale / 0.25f));
        
        transform.position = new Vector3(player.GetComponent<Rigidbody2D>().position.x, player.GetComponent<Rigidbody2D>().position.y + 2, -10);

        

    }
}
