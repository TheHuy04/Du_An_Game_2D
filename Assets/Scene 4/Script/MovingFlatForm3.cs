using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class musroom : MonoBehaviour
{
    public Rigidbody2D rb;
    public float timer = 1f;
    public float health = 5f;
    public int points = 4;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(movingflatform());
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == 1)
        {
            transform.Translate(Vector3.left * 3f * Time.deltaTime);
            transform.localScale = new Vector3(-1f,1f, 1f);
        }
        else if(timer == 0)
        {
            transform.Translate(Vector3.right * 3f * Time.deltaTime);
            transform.localScale = new Vector3(1f,1f, 1f);
        }
        if (health == 0)
        {
            Destroy(this.gameObject);
            Player4 kill2 = GameObject.FindWithTag("Player").GetComponent<Player4>();
            if (kill2 != null)
            {
                kill2.addscore(points);
            }
        }
    }
    IEnumerator movingflatform()
    {
        while(timer == 1)
        {
            timer -= 1;
            yield return new WaitForSeconds(2.5f);
            while (timer == 0)
            {
                timer += 1;
                yield return new WaitForSeconds(2.5f);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("jump"))
        {
            rb.AddForce(Vector2.up * 5f,ForceMode2D.Impulse);
        }
        if (collision.CompareTag("bullet"))
        {
            health -= 1f;
            Destroy(collision.gameObject);
        }
    }
}
