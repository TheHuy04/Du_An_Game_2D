


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player3 : MonoBehaviour
{
    public float speed;
    public float jumForce;
    private Rigidbody2D rb;
    private float h_move;
    private bool nhay1L;
    bool Alive = true;
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
        //di chuyen
        h_move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h_move * speed, rb.velocity.y);
        anm.SetFloat("isRunning",Mathf.Abs(h_move));
        anm.SetBool("isJumping",true);

        if(Input.GetKeyDown(KeyCode.Space) && nhay1L)
        {
            rb.AddForce(Vector2.up * jumForce, ForceMode2D.Impulse);
            nhay1L = false;
        }
        if (Alive == false) return;

        Flip();
    }

    private void Flip()
    {
        SpriteRenderer sp = transform.GetComponent<SpriteRenderer>();
        if((h_move > 0 && sp.flipX) || (h_move < 0 && !sp.flipX))
        {
            sp.flipX = !sp.flipX;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            nhay1L = true;
        }
        if(Alive == false) return;
    }   
}
