using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenGround : MonoBehaviour
{
    private float yRange = 1.9f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= yRange)
        {
            Destroy(gameObject);
        }
    }
}
