using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject background;
    public GameObject bar;
    public float width;
    // Start is called before the first frame update
    void Start()
    {
        width = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        bar.transform.position = transform.position - new Vector3((width / 2), 0);
        background.transform.position = bar.transform.position - new Vector3(0.025f, 0);

    }

    public void SetBar(float fraction)
    {
        if (fraction < 0.33f)
        {
            bar.GetComponent<SpriteRenderer>().color = new Color(231f/255f, 76f/255f, 60f/255f); //red
        }
        else if (fraction < 0.66f)
        {
            bar.GetComponent<SpriteRenderer>().color = new Color(244f/255f, 208f/255f, 63f/255f); //yellow

        }
        else
        {
            bar.GetComponent<SpriteRenderer>().color = new Color(40f/255f, 222f/255f, 67f/255f); //green
        }
        bar.transform.localScale = new Vector3(width * fraction, 0.15f, transform.localScale.z);
    }
}
