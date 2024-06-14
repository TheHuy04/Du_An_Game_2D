using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Player4 : MonoBehaviour
{
    public GameObject die, pause, arrowprefab;
    public float diem = 0;
    public Rigidbody2D qf;
    public bool jump, climbing;
    public Animator ani;
    public int mang = 3;
    public Text lifetext, pointtext;
    public Transform bowpos,checkpoint;
    public AudioSource udio, adi, dio, eio;
    // Start is called before the first frame update
    void Start()
    {
        qf = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        Time.timeScale = 1.0f;
        udio = GetComponent<AudioSource>();
        adi = GetComponent<AudioSource>();
        dio = GetComponent<AudioSource>();
        eio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
            transform.localScale = new Vector3(1f, 1f, 1f);
            ani.SetBool("Speed", true);
            adi.Play();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * 5f * Time.deltaTime);
            transform.localScale = new Vector3(-1f, 1f, 1f);
            ani.SetBool("Speed", true);
            adi.Play();
        }
        else ani.SetBool("Speed", false);
        if (Input.GetKeyDown(KeyCode.UpArrow) && jump)
        {
            udio.Play();
            qf.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }
        if (mang < 1)
        {
            Destroy(this.gameObject);
            die.SetActive(true);
        }
        if (climbing)
        {
            var leothang = Input.GetAxisRaw("Horizontal");
            var leothang2 = Input.GetAxisRaw("Vertical");
            qf.velocity = new Vector3(leothang * 1f, leothang2 * 3f, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetBool("shoot",true);
            shoot();
        }
        else ani.SetBool("shoot",false);
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pause.SetActive(true);
        }
    }
    public void addscore(int points)
    {
        diem += points;
        pointtext.text = points + " Coin";
    }
    public void shoot()
    {
        dio.Play();
        GameObject arr = Instantiate(arrowprefab, bowpos.position, bowpos.rotation);
        Rigidbody2D rb = arr.GetComponent<Rigidbody2D>();
        rb.AddForce(bowpos.right * 50f * Mathf.Sign(transform.localScale.x), ForceMode2D.Impulse);
        Destroy(rb.gameObject, 2f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            jump = true;
            ani.SetBool("Force", false);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            mang -= 1;
            lifetext.text = "Life " + mang;
            transform.position = checkpoint.position;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            jump = false;
            ani.SetBool("Force",true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            eio.Play();
            qf.gravityScale = 0;
            climbing = true;
            ani.SetBool("climbing", true);
        }
        if (collision.CompareTag("Enemy"))
        {
            mang -= 1;
            lifetext.text = "Life " + mang;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            eio.Stop();
            qf.gravityScale = 1f;
            climbing = false;
            ani.SetBool("climbing",false);
        }
    }
}
