using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingenemy : MonoBehaviour
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
            transform.localScale = new Vector3(-1f,1f, 1f);
        }
        else if(timer == 0)
        {
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
            transform.localScale = new Vector3(1f,1f, 1f);
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
}
