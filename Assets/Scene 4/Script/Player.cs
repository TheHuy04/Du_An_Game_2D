using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public Rigidbody2D qf;
    public bool jump;
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        qf = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
            transform.localScale = new Vector3(1f, 1f, 1f);
            ani.SetBool("Speed", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 5f * Time.deltaTime);
            transform.localScale = new Vector3(-1f, 1f, 1f);
            ani.SetBool("Speed", true);
        }
        else ani.SetBool("Speed", false);
        if (Input.GetKeyDown(KeyCode.W)&&jump)
        {
            qf.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = true;
            ani.SetBool("Force", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = false;
            ani.SetBool("Force", true);
        }
    }
}
