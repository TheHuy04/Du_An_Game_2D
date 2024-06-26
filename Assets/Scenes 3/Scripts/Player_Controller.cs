﻿using System;
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

    // Biến dash
    public float dashSpeed;
    public float dashTime;
    private bool isDashing;
    private float dashTimeLeft;
    public float dashCooldown;
    private float dashCooldownTime;

    public bool Climb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            Dash();
        }
        else
        {
            h_move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(h_move * speed, rb.velocity.y);
            anm.SetFloat("Running", Mathf.Abs(h_move));

            if (Input.GetKeyDown(KeyCode.Space) && nhay1L)
            {
                rb.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
                nhay1L = false;
                anm.SetBool("Jumping", true);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= dashCooldownTime)
            {
                StartDash();
            }

            Flip();
        }
        if (Climb)
        {
            var lenThang = Input.GetAxisRaw("Horizontal");
            var lenThang2 = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector3(lenThang * 1f, lenThang2 * 3f, 0f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lader3"))
        {
            rb.gravityScale = 0;
            Climb = true;
            anm.SetBool("Thang", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Lader3"))
        {
            rb.gravityScale = 2f;
            Climb = false;
            anm.SetBool("Thang", false);

        }

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

    void StartDash()
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        dashCooldownTime = Time.time + dashCooldown;
        rb.velocity = new Vector2((isfacingRight ? 1 : -1) * dashSpeed, rb.velocity.y);
        anm.SetTrigger("Dash");
    }

    void Dash()
    {
        if (dashTimeLeft > 0)
        {
            dashTimeLeft -= Time.deltaTime;
            rb.velocity = new Vector2((isfacingRight ? 1 : -1) * dashSpeed, rb.velocity.y);
        }
        else
        {
            isDashing = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            nhay1L = true;
            anm.SetBool("Jumping", false);
        }
    }

}
