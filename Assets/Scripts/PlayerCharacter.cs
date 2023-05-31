using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	public Joystick joystick;

    public Joystick aimstick;
    private string aimstickState;

    public GameObject aimLine; //child of player, will move along
    private float aimAngle;
    public Rigidbody2D rbAimLine;


    public float movementSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        
        aimLine.SetActive(false);
        movementSpeed = 3;
        aimstickState = "Rest";
        return;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("HorizontalMovement", joystick.Horizontal);
        animator.SetFloat("VerticalMovement", joystick.Vertical);
        animator.SetFloat("Speed", rb.velocity.magnitude);
        // generate aimLine according to aimstick

        //with aimLine
        if (Mathf.Abs(aimstick.Horizontal) >= 0.2f || Mathf.Abs(aimstick.Vertical) >= 0.2f)
        {
            aimLine.SetActive(true);
            aimstickState = "Aiming";
            Vector2 direction;
            direction = new Vector2(aimstick.Horizontal, aimstick.Vertical);
            aimAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rbAimLine.rotation = aimAngle;
            

        }
        //autoaim
        else if (Mathf.Abs(aimstick.Horizontal) < 0.2f && Mathf.Abs(aimstick.Vertical) < 0.2f)
        {
            aimLine.SetActive(false);
            aimstickState = "AutoAiming";
        }
        //release
        else if (Mathf.Abs(aimstick.Horizontal) == 0f || Mathf.Abs(aimstick.Vertical) == 0f)
        {
            switch (aimstickState)
            {
                case "Rest":
                    break;
                case "Aiming":
                    Shoot(aimAngle);
                    break;
                case "AutoAiming":
                    Shoot(rb.rotation);
                    break;
                default:
                    break;
            }
            aimLine.SetActive(false);
            aimstickState = "Rest";
            
        }
    }

    public void Shoot(float angle)
    {

    }

    void FixedUpdate()
    {

        // moves according to joystick
        if (Mathf.Abs(joystick.Horizontal) >= 0.2f || Mathf.Abs(joystick.Vertical) >= 0.2f)
        {
            Vector2 direction;
            direction = new Vector2(joystick.Horizontal, joystick.Vertical);
            direction.Normalize();
            direction *= movementSpeed;
            rb.velocity = direction;

        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        return;
    }
}
