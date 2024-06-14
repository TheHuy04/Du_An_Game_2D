using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Player4 : MonoBehaviour
{
    public GameObject pause, arrowprefab;
    public float diem = 0, timer = 0f,dietime = 3f;
    public Rigidbody2D qf;
    public bool jump, climbing;
    public Animator ani;
    public Text pointtext;
    public Transform bowpos, checkpoint;
    public AudioSource udio, adi, dio, eio;
    public Slider slider;
    public float hpslider = 100f;
    // Start is called before the first frame update
    void Start()
    {
        qf = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        udio = GetComponent<AudioSource>();
        adi = GetComponent<AudioSource>();
        dio = GetComponent<AudioSource>();
        eio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hpslider <= 0)
        {
            ani.SetBool("dieskil",true);
            Destroy(this.gameObject,2f);
        }
        else ani.SetBool("dieskil",false);
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
            qf.AddForce(Vector2.up * 7f, ForceMode2D.Impulse);
        }
        if (climbing)
        {
            var leothang = Input.GetAxisRaw("Horizontal");
            var leothang2 = Input.GetAxisRaw("Vertical");
            qf.velocity = new Vector3(leothang * 1f, leothang2 * 3f, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && timer == 0f)
        {
            shoot();
            timer += 1f;
            StartCoroutine(loadingtime());
        }
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
        Destroy(rb.gameObject, 0.1f);
        if (timer == 0f)
        {
            ani.SetBool("shoot", true);
        }
        else if (timer > 0f)
        {
            ani.SetBool("shoot", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("moving"))
        {
            jump = true;
            ani.SetBool("Force", false);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hpslider -= 10f;
            slider.value = hpslider;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")||collision.gameObject.CompareTag("moving"))
        {
            jump = false;
            ani.SetBool("Force", true);
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
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            eio.Stop();
            qf.gravityScale = 1f;
            climbing = false;
            ani.SetBool("climbing", false);
        }
    }
    IEnumerator loadingtime()
    {
        while (timer == 1f)
        {
            timer += 1f;
            yield return new WaitForSeconds(1f);
            while (timer == 2f)
            {
                timer -= 2f;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
