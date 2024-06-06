using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class boss : MonoBehaviour
{
    public float timers = 1f;
    public Transform bolt, pulse, charged, spark, waveform;
    public GameObject boltb, pulseb, chargedb, sparkb, waveformb;
    public float boltt = 1f, pulset = 1f, chargedt = 1f, sparkt = 1f, waveformt = 1f;
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bossat());
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timers == 1f)
        {
            ani.SetBool("skill1", true);
        }
        else ani.SetBool("skill1",false);
        if (timers == 2f)
        {
            ani.SetBool("skill2", true);
        }
        else ani.SetBool("skill2", false);
        if (timers == 3f)
        {
            ani.SetBool("skill3", true);
        }
        else ani.SetBool("skill3",false);
        if (timers == 4f)
        {
            ani.SetBool("skill4", true);
        }
        else ani.SetBool("skill4",false);
        if (timers == 5f)
        {
            ani.SetBool("skill5", true);
        }
        else ani.SetBool("skill5",false);
    }
    public void shootbolt()
    {
        GameObject arr = Instantiate(boltb, bolt.position, bolt.rotation);
        Rigidbody2D rb = arr.GetComponent<Rigidbody2D>();
        rb.AddForce(bolt.right * 10f * Mathf.Sign(transform.localScale.x), ForceMode2D.Impulse);
        Destroy(rb.gameObject, 2f);
    }
    public void shootpulse()
    {
        GameObject arr = Instantiate(pulseb, pulse.position, pulse.rotation);
        Rigidbody2D rb = arr.GetComponent<Rigidbody2D>();
        rb.AddForce(pulse.right * 10f * Mathf.Sign(transform.localScale.x), ForceMode2D.Impulse);
        Destroy(rb.gameObject, 2f);
    }
    public void shootcharged()
    {
        GameObject arr = Instantiate(chargedb, charged.position, charged.rotation);
        Rigidbody2D rb = arr.GetComponent<Rigidbody2D>();
        rb.AddForce(charged.right * 10f * Mathf.Sign(transform.localScale.x), ForceMode2D.Impulse);
        Destroy(rb.gameObject, 2f);
    }
    public void shootspark()
    {
        GameObject arr = Instantiate(sparkb, spark.position, spark.rotation);
        Rigidbody2D rb = arr.GetComponent<Rigidbody2D>();
        rb.AddForce(spark.right * 10f * Mathf.Sign(transform.localScale.x), ForceMode2D.Impulse);
        Destroy(rb.gameObject, 2f);
    }
    public void shootwaveform()
    {
        GameObject arr = Instantiate(waveformb, waveform.position, waveform.rotation);
        Rigidbody2D rb = arr.GetComponent<Rigidbody2D>();
        rb.AddForce(waveform.right * 10f * Mathf.Sign(transform.localScale.x), ForceMode2D.Impulse);
        Destroy(rb.gameObject, 2f);
    }
    IEnumerator bossat()
    {
        while (timers == 1)
        {
            timers += 1;
            if(boltt == 1f)
            {
                shootbolt();
                boltt -= 1f;
            }
            yield return new WaitForSeconds(2f);
            while (timers == 2)
            {
                timers += 1;
                boltt += 1f;
                if(pulset == 1f)
                {
                    shootpulse();
                    pulset -= 1f;
                }
                yield return new WaitForSeconds(2f);
                while(timers == 3)
                {
                    timers += 1;
                    pulset += 1f;
                    if(chargedt == 1f)
                    {
                        shootcharged();
                        chargedt -= 1f;
                    }
                    yield return new WaitForSeconds(2f);
                    while(timers == 4)
                    {
                        timers += 1f;
                        chargedt += 1f;
                        if(sparkt == 1f)
                        {
                            shootspark();
                            sparkt -= 1f;
                        }
                        yield return new WaitForSeconds(2f);
                        while(timers == 5)
                        {
                            timers += 1f;
                            sparkt += 1f;
                            if(waveformt == 1f)
                            {
                                shootwaveform();
                                waveformt -= 1f;
                            }
                            yield return new WaitForSeconds(2f);
                            while(timers == 6)
                            {
                                timers -= 5f;
                                waveformt += 1f;
                            }
                        }
                    }
                }
            }
        }
    }
}
