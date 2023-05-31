using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thicc : Bullet
{
    public GameObject fraggPrefab;
    bool goingForward;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        maxLength = 3;
        damage = 50;
        lifeTime = maxLength / speed;
        rb = GetComponent<Rigidbody2D>();

        Vector3 audio1Location = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        AudioSource.PlayClipAtPoint(audioClip1, Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        rbGraphics.position = rb.position;
        timePassed += Time.deltaTime;
        if (timePassed > lifeTime)
        {
            Vector3 audio2Location = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
            AudioSource.PlayClipAtPoint(audioClip2, Camera.main.transform.position);
            for (int i = 0; i < 7; i++)
            {
                GameObject newFragg = Instantiate(fraggPrefab);
                newFragg.transform.position = transform.position;
                newFragg.GetComponent<Bullet>().rbGraphics.rotation = rbGraphics.rotation + (i - 3) * 10;
                newFragg.GetComponent<Bullet>().from = from;
            }
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        base.FixedUpdate();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
