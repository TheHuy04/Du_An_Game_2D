using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private float h_move;
    public float speed;
    public float Jump;
    private Rigidbody2D rb;
    private Animator anm;
    private bool nhay1L;
    private bool isfacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h_move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h_move * speed, rb.velocity.y);
        anm.SetFloat("Running", Mathf.Abs(h_move));
        if (Input.GetKeyDown(KeyCode.Space) && nhay1L)
        {
            rb.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
            nhay1L = false;
        }

        Flip();

    }
    void Flip()
    {
        if (isfacingRight && h_move < 0 || !isfacingRight && h_move > 0)
        {
            isfacingRight = !isfacingRight;
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            nhay1L = true;
        }
        else
        {
            anm.SetBool("Jumping", false);
        }
    }

}
