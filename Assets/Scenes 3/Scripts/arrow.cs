using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public float lifeTime = 0.5f;
    private Rigidbody2D rb;


    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
 
    }
}
