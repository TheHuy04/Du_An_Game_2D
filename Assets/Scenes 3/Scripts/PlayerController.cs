using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int move;
    public float speed;
    public int Jump;
    private Rigidbody2D rb;
    private Animator anm;


    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            move = -1;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            move = 1;
        }else move = 0;
        transform.Translate(Vector3.right * speed * move * Time.deltaTime); 

        if(Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector2.up *Jump * Time.deltaTime);
        }
    }
}
