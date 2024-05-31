using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class flyingenemy : MonoBehaviour
{
    public float health = 4f;
    public float timer = 1f;
    public int points = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(movingflatform());
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == 1)
        {
            transform.Translate(Vector3.left * 5f * Time.deltaTime);
            transform.localScale = new Vector3(-1f,1f, 1f);
        }
        else if(timer == 0)
        {
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
            transform.localScale = new Vector3(1f,1f, 1f);
        }
        if(health == 0)
        {
            Destroy(this.gameObject);
            Player4 kill = GameObject.FindWithTag("Player").GetComponent<Player4>();
            if(kill != null)
            {
                kill.addscore(points);
            }
        }
    }
    IEnumerator movingflatform()
    {
        while(timer == 1)
        {
            timer -= 1;
            yield return new WaitForSeconds(2f);
            while (timer == 0)
            {
                timer += 1;
                yield return new WaitForSeconds(2f);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            health -= 1f;
            Destroy(collision.gameObject);
        }
    }
}
