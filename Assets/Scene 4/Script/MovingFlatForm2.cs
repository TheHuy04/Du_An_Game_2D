using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    public float health = 2f;
    public float timer = 1f;
    public int points = 1;
    public ScoreKeeper scorekeeper;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(movingflatform());
        scorekeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == 1)
        {
            transform.Translate(Vector3.left * 2f * Time.deltaTime);
            transform.localScale = new Vector3(-1f,1f, 1f);
        }
        else if(timer == 0)
        {
            transform.Translate(Vector3.right * 2f * Time.deltaTime);
            transform.localScale = new Vector3(1f,1f, 1f);
        }
        if(health == 0)
        {
            Destroy(this.gameObject);
            scorekeeper.tangdiem(points);
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
        if (collision.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);
            health -= 1f;
        }
    }
}
