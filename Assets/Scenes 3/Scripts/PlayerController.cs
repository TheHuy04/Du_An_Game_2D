using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float h_move;
    public float speed;
    public float Jump;
    private Rigidbody2D rb;
    private Animator anm;
    private bool nhay1L;
    private bool isfacingRight = true;

    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float arrowSpeed;
    public float fireRate = 0.5f;
    private float nextFireTime;

    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    private bool isDashing;
    private float dashTime;
    private float dashCooldownTime;


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
        anm.SetFloat("isRunning", Mathf.Abs(h_move));



        if (Input.GetKeyDown(KeyCode.Space) && nhay1L)
        {
            rb.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
            nhay1L = false;

        }

        Flip();
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
        if (isDashing)
        {
            if (Time.time >= dashTime)
            {
                isDashing = false;
                rb.velocity = new Vector2(0, rb.velocity.y); // Dừng lại khi dash kết thúc
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= dashCooldownTime)
        {
            Dash();
        }

    }
    void Shoot()
    {
        anm.SetTrigger("Attack");

        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        Rigidbody2D rbArrow = arrow.GetComponent<Rigidbody2D>();
        if (isfacingRight)
        {
            rbArrow.velocity = new Vector2(arrowSpeed, 0);
        }
        else
        {
            rbArrow.velocity = new Vector2(-arrowSpeed, 0);
        }
        arrow.transform.localScale = new Vector3(isfacingRight ? 1 : -1, 1, 1);
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
            anm.SetBool("isJumping", false);
        }
    }
    private void Dash()
    {
        isDashing = true;
        dashTime = Time.time + dashDuration;
        dashCooldownTime = Time.time + dashCooldown;

        float dashDirection = isfacingRight ? 1 : -1;
        rb.velocity = new Vector2(dashDirection * dashSpeed, 0); // Đặt vận tốc dash

        // Kích hoạt animation dash
        anm.SetTrigger("Dash");

        // Gỡ lỗi
        Debug.Log(rb.velocity.x);
    }
}