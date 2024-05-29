using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    public Rigidbody2D qf;
    public bool jump;
    public Animator ani;
    public int mang = 3;
    public Text lifetext;
    public Transform checkpoint;
    public bool climbing;
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
        if (Input.GetKeyDown(KeyCode.W) && jump)
        {
            qf.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }
        if(mang < 1)
        {
            Destroy(this.gameObject);
        }
        if (climbing)
        {
            var leothang = Input.GetAxisRaw("Horizontal");
            var leothang2 = Input.GetAxisRaw("Vertical");
            qf.velocity = new Vector3(leothang *1f, leothang2 *3f, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = true;
            ani.SetBool("Force", false);
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            mang -= 1;
            lifetext.text = "Life " + mang;
            transform.position = checkpoint.position;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = false;
            ani.SetBool("Force",true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("lander"))
        {
            qf.gravityScale = 0;
            climbing = true;
            ani.SetBool("climbing", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("lander"))
        {
            qf.gravityScale = 1f;
            climbing = false;
            ani.SetBool("climbing",false);
        }
    }
}
