using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFlatForm : MonoBehaviour
{
    public float timer = 1f;
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
        }
        else if(timer == 0)
        {
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
        }
    }
    IEnumerator movingflatform()
    {
        while(timer == 1)
        {
            timer -= 1;
            yield return new WaitForSeconds(7.5f);
            while (timer == 0)
            {
                timer += 1;
                yield return new WaitForSeconds(7.5f);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
