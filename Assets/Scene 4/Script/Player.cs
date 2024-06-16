using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Player4 : MonoBehaviour
{
    public GameObject pause, arrowprefab, botsp;
    public float diem = 0,dietime = 3f, hpslider, maxhp = 100f, timershoot = 0f, skills = 0f, timerspawn = 0f;
    public Rigidbody2D qf;
    public bool jump, climbing, fire, attackmove;
    public Animator ani;
    public Transform bowpos;
    public Slider slider;
    public AudioSource jumps, attacks, climbs;
    // Start is called before the first frame update
    void Start()
    {
        qf = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        maxhp = hpslider;
        if(hpslider > maxhp)
        {
            hpslider = 100f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!attackmove)
        {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
            transform.localScale = new Vector3(1f, 1f, 1f);
            ani.SetBool("Speed", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * 5f * Time.deltaTime);
            transform.localScale = new Vector3(-1f, 1f, 1f);
            ani.SetBool("Speed", true);
        }
        else ani.SetBool("Speed", false);
        }
        if(hpslider <= 0)
        {
            ani.SetBool("dieskil",true);
            Destroy(this.gameObject,2f);
        }
        else ani.SetBool("dieskil",false);
        if (Input.GetKeyDown(KeyCode.UpArrow) && jump)
        {
            jumps.Play();
            qf.AddForce(Vector2.up * 7f, ForceMode2D.Impulse);
        }
        if (climbing)
        {
            var leothang = Input.GetAxisRaw("Horizontal");
            var leothang2 = Input.GetAxisRaw("Vertical");
            qf.velocity = new Vector3(leothang * 1f, leothang2 * 3f, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && timershoot == 0f && fire)
        {
            attackmove = true;
            timershoot += 1f;
            ani.SetBool("shoot",true);
            ani.SetBool("Speed",false );
            attacks.Play();
            GameObject go = Instantiate(arrowprefab, bowpos.position, bowpos.rotation);
            Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
            rb.AddForce(bowpos.right * 20f * Mathf.Sign(transform.localScale.x), ForceMode2D.Impulse);
            Destroy(rb.gameObject,0.05f);
            StartCoroutine(loadingshoot());
        }
        else if(timershoot == 3f)
        {
            ani.SetBool("shoot",false);
            attackmove = false;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pause.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.F) && skills == 1f && timerspawn == 0f)
        {
            timerspawn += 1f;
            GameObject bot = Instantiate(botsp, bowpos.position, bowpos.rotation);
            StartCoroutine(loadid());
        }
    }
    public void skill(int chieuthuc)
    {
        skills += chieuthuc;
    }
    public void trumau(int mau)
    {
        hpslider -= mau;
        slider.value = hpslider;
    }
    public void addscore(int points)
    {
        diem += points;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("moving"))
        {
            fire = true;
            jump = true;
            ani.SetBool("Force", false);
        }
        if (collision.gameObject.CompareTag("Enemys"))
        {
            hpslider -= 10f;
            slider.value = hpslider;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")||collision.gameObject.CompareTag("moving"))
        {
            fire = false;
            jump = false;
            ani.SetBool("Force", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            jumps.Stop();
            climbs.Play();
            qf.gravityScale = 0;
            climbing = true;
            ani.SetBool("climbing", true);
        }
        if (collision.CompareTag("bossfire"))
        {
            hpslider -= 0.1f;
            slider.value = hpslider;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            climbs.Stop();
            qf.gravityScale = 1f;
            climbing = false;
            ani.SetBool("climbing", false);
        }
    }
    IEnumerator loadingshoot()
    {
        while(timershoot == 1f)
        {
            timershoot += 1f;
            yield return new WaitForSeconds(0.5f);
            while(timershoot == 2f)
            {
                timershoot += 1f;
                yield return new WaitForSeconds(0.5f);
                while(timershoot == 3f)
                {
                    timershoot -= 3f;
                    yield return new WaitForSeconds(0.5f);
                }
            }
        }
    }
    IEnumerator loadid()
    {
        while(timerspawn == 1f)
        {
            timerspawn -= 1f;
            yield return new WaitForSeconds(10f);
        }
    }
}
