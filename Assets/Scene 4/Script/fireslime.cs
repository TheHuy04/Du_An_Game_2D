using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class fireslime : MonoBehaviour
{
    public GameObject slimebullletprefab;
    public Transform fireball;
    public float timers = 1f;
    public float health = 4f;
    public Text cointext;
    public float coin;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timeforshoot());
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
        if(health == 0)
        {
            Destroy(this.gameObject);
            coin += 3f;
            cointext.text = coin + " Coin";
        }
    }
    IEnumerator timeforshoot()
    {
        while (timers == 1)
        {
            timers -= 1;
            yield return new WaitForSeconds(0.005f);
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