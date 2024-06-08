using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climp : MonoBehaviour
{
    public float Climpspeed = 3;
    private bool isclimping = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lader3"))
        {
            isclimping=true;
            rb.gravityScale = 0f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Lader3"))
        {
            isclimping=false;
            rb.gravityScale = 1f;
        }
    }
    private void FixedUpdate()
    {
        if (isclimping)
        {
            float climpInput = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, climpInput * Climpspeed);
        }
    }
}
