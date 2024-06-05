using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fireslime : MonoBehaviour
{
    public GameObject slimebullletprefab;
    public Transform fireball;
    public float timers = 1f;
    public float health = 5f;
    public int points = 4;
    public ScoreKeeper scorekeeper;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timeforshoot());
        scorekeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
        if(health == 0)
        {
            Destroy(this.gameObject);
            scorekeeper.tangdiem(points);
        }
    }
    IEnumerator timeforshoot()
    {
        while (timers == 1)
        {
            timers -= 1;
            yield return new WaitForSeconds(0.0005f);
            while (timers == 0)
            {
                timers += 1;
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
    public void shoot()
    {
        if(timers == 0)
        {
            GameObject go = Instantiate(slimebullletprefab, fireball.position, fireball.rotation);
            Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
            rb.AddForce(fireball.right * 26f * Mathf.Sign(transform.localScale.x), ForceMode2D.Impulse);
            Destroy(rb.gameObject, 1.5f);
        }
    }
}