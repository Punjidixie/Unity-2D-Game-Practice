using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Reference reference;
    public GameObject bulletPrefab;
    public Rigidbody2D rbGraphics;
    public Animator animator;
    public GameObject aimLine;

    public Joystick joystick; //set from reference
    public Joystick aimstick; //set from aimLine
    string aimstickState;

    
    public float aimAngle;
    Rigidbody2D rbAimLine;

    public Rigidbody2D rb;

    public float movementSpeed;
    public float maxSpeed;
    public float energy;
    public float maxEnergy;
    public float energyRecoveryRate;
    public float energyConsumption;
    public float hp;
    public float maxHp;
    public bool moveFromExternalSource;

    // Start is called before the first frame update
    protected void Start()
    {
        joystick = reference.joystick;
        aimstick = reference.aimstick;

        rb = GetComponent<Rigidbody2D>();
        rbAimLine = aimLine.GetComponent<Rigidbody2D>();

        aimLine.SetActive(false);
        aimstickState = "Rest";

        energy = 100;
        maxEnergy = energy;
        energyRecoveryRate = 10; //per second
        energyConsumption = 20;
        hp = 1000;
        maxHp = hp;
        movementSpeed = 3;
        maxSpeed = movementSpeed;

        moveFromExternalSource = false;
        return;
    }

    // Update is called once per frame
    protected void Update()
    {
        //animator.SetFloat("HorizontalMovement", joystick.Horizontal);
        //animator.SetFloat("VerticalMovement", joystick.Vertical);
        
        animator.SetFloat("Speed", rb.velocity.magnitude);
        rbAimLine.position = rb.position;
        rbGraphics.transform.position = rb.transform.position;
        // generate aimLine according to aimstick

        //with aimLine
        //release
        if (Mathf.Abs(aimstick.Horizontal) == 0f || Mathf.Abs(aimstick.Vertical) == 0f)
        {
            
            switch (aimstickState)
            {
                case "Rest":
                    break;
                case "Cancel":
                    break;
                case "Aiming":
                    if (animator.GetBool("Shooting") == false && energy > energyConsumption)
                    {
                        animator.SetBool("Shooting", true); //trigger shooting animation
                        energy -= energyConsumption;
                    }
                    break;
                case "AutoAiming":
                    if (animator.GetBool("Shooting") == false && energy > energyConsumption)
                    {
                        animator.SetBool("Shooting", true); //trigger shooting animation
                        energy -= energyConsumption;
                    }
                    break;
                default:
                    break;
            }
            aimLine.SetActive(false);
            aimstickState = "Rest";

        }
        //aiming
        else if (Mathf.Abs(aimstick.Horizontal) >= 0.1f || Mathf.Abs(aimstick.Vertical) >= 0.1f)
        {
            aimLine.SetActive(true);
            aimstickState = "Aiming";
            Vector2 direction;
            direction = new Vector2(aimstick.Horizontal, aimstick.Vertical);
            aimAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rbAimLine.rotation = aimAngle;



        }
        //autoaim
        else if (Mathf.Abs(aimstick.Horizontal) < 0.1f && Mathf.Abs(aimstick.Vertical) < 0.1f)
        {
            aimLine.SetActive(false);
            switch (aimstickState)
            {
                case "Aiming":
                    aimstickState = "Cancel";
                    break;
                case "Cancel":
                    aimstickState = "Cancel";
                    break;
                case "Rest":
                    aimstickState = "AutoAiming";
                    break;
                default:
                    aimstickState = "AutoAiming";
                    break;
            }
            
            aimAngle = rbGraphics.rotation;
        }
        if (Input.GetMouseButtonDown(0))
        {
            
        }
        //if (Input.GetMouseButtonUp(0))
        //{
        //    aimstickState = "Aiming";
        //    Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(rb.position.x, rb.position.y);
        //    aimAngle = Mathf.Atan2(direction.y, direction.x);
        //    switch (aimstickState)
        //    {
        //        case "Rest":
        //            break;
        //        case "Aiming":
        //            if (animator.GetBool("Shooting") == false && energy > energyConsumption)
        //            {
        //                animator.SetBool("Shooting", true); //trigger shooting animation
        //                energy -= energyConsumption;
        //            }
        //            break;
        //        case "AutoAiming":
        //            if (animator.GetBool("Shooting") == false && energy > energyConsumption)
        //            {
        //                animator.SetBool("Shooting", true); //trigger shooting animation
        //                energy -= energyConsumption;
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //    aimLine.SetActive(false);
        //    aimstickState = "Rest";
        //}

            energy += energyRecoveryRate * Time.deltaTime;
        if (energy > maxEnergy)
        {
            energy = maxEnergy;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            hp = maxHp;
        }
    }

    // just a single bullet
    public virtual void Shoot(float angle)
    {
        //Debug.Log("Shoot function");
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = transform.position;
        newBullet.GetComponent<Bullet>().rbGraphics.rotation = angle;

        //set from
        newBullet.GetComponent<Bullet>().from = gameObject.GetComponent<Player>();
    }

    protected void FixedUpdate()
    {
        if (moveFromExternalSource)
        {
            
        }
        else
        {
            MoveFromJoystick();
        }
        
        
        return;
    }
    public void MoveFromJoystick()
    {
        // moves according to joystick
        if (Mathf.Abs(joystick.Horizontal) >= 0.1f || Mathf.Abs(joystick.Vertical) >= 0.1f)
        {
            Vector2 direction;
            direction = new Vector2(joystick.Horizontal, joystick.Vertical);
            direction.Normalize();
            direction *= movementSpeed;
            rb.velocity = direction;
            rbGraphics.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        }
        //move according to mouse
        else if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && hp != 0)
        {
            Vector2 direction;
            direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            direction.Normalize();
            direction *= movementSpeed;
            rb.velocity = direction;
            rbGraphics.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
    public void HitBy(EnemyBullet enemyBullet)
    {
        hp -= enemyBullet.damage;
        if (hp <= 0)
        {
            
            hp = 0;
            
            
        }
    }

    public void HealsBy(float heal)
    {
        hp += heal;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
    }
}
