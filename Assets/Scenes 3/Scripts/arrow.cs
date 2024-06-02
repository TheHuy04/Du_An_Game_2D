using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public float lifeTime = 2f;
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
