using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class skeletons : MonoBehaviour
{
    public float timer = 1f;
    public float health = 10f;
    public int points = 9;
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
            transform.Translate(Vector3.left * 3f * Time.deltaTime);
            transform.localScale = new Vector3(-1f,1f, 1f);
        }
        else if(timer == 0)
        {
            transform.Translate(Vector3.right * 3f * Time.deltaTime);
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
            health -= 1;
            Destroy(collision.gameObject);
        }
    }
}
