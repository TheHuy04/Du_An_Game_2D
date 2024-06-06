using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public float timers = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bossat());
    }

    // Update is called once per frame
    void Update()
    {
        if(timers == 1f)
        {
            Debug.Log("tao là huy");
        }
    }
    IEnumerator bossat()
    {
        while (timers == 1)
        {
            timers += 1;
            yield return new WaitForSeconds(1f);
            while (timers == 2)
            {
                timers += 1;
                yield return new WaitForSeconds(1f);
                while(timers == 3)
                {
                    timers += 1;
                    yield return new WaitForSeconds(1f);
                    while(timers == 4)
                    {
                        timers += 1f;
                        yield return new WaitForSeconds(1f);
                        while(timers == 5)
                        {
                            timers -= 4f;
                            yield return new WaitForSeconds(1f);
                        }
                    }
                }
            }
        }
    }
}
