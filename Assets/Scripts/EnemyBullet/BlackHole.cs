using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : EnemyBullet
{

    
    public bool active;
    public CircleCollider2D circleCollider;
    public float expansionRate;
    public float graphicsExpansionRate;
    public float maxRadius;
    public float lifeTimeAfter;
    public float suckingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = 0.3f;
        active = false;
        expansionRate = 10;
        graphicsExpansionRate = (rbGraphics.gameObject.transform.localScale.x / circleCollider.radius) * expansionRate;
        lifeTimeAfter = 4;
        maxRadius = 4;
        suckingSpeed = 3;

        speed = 1;
        maxLength = 6;
        damage = 40;
        lifeTime = maxLength / speed;
        
        rb = GetComponent<Rigidbody2D>();
        rb.rotation = -90;
        playerSet = new HashSet<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        rbGraphics.position = rb.position;
    }

    private void FixedUpdate()
    {
        timePassed += Time.fixedDeltaTime;
        if (timePassed < lifeTime)
        {
            rb.velocity = new Vector2(0, -speed);
        }
        else if (timePassed < lifeTime + lifeTimeAfter)
        {
            active = true;
            rb.velocity = Vector2.zero;
            if (circleCollider.radius < maxRadius)
            {
                circleCollider.radius += expansionRate * Time.fixedDeltaTime;
                rbGraphics.transform.localScale += new Vector3(graphicsExpansionRate, graphicsExpansionRate) * Time.fixedDeltaTime;
            }
            else
            {
                circleCollider.radius = maxRadius;
            }
        }
        else
        {
            Destroy(gameObject);
            foreach (Player playerScript in playerSet)
            {
                playerScript.moveFromExternalSource = false;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("GAYYYY");
       if (active)
        {
            if (collision.gameObject.tag == "Player")
            {
                Player playerScript = collision.gameObject.GetComponent<Player>();
                playerScript.moveFromExternalSource = true;
                Vector2 direction = rb.position - playerScript.rb.position;
                playerScript.rb.velocity = direction.normalized * suckingSpeed;

                if (!playerSet.Contains(playerScript))
                {
                    playerSet.Add(playerScript); //for ending
                }
               
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (Player playerScript in playerSet)
        {
            playerScript.moveFromExternalSource = false;
        }
    }

}
