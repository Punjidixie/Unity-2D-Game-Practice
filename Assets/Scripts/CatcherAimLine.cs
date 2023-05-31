using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatcherAimLine : MonoBehaviour
{
    Catcher catcher;
    Boomerang boomerang;
    // Start is called before the first frame update
    void Start()
    {
        catcher = GetComponentInParent<Catcher>();
        boomerang = catcher.bulletPrefab.GetComponent<Boomerang>();
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3(10 * 1 - 0.5f * 8, 0.5f);
    }
}
