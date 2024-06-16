using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button2 : MonoBehaviour
{
    public AudioSource ped, xpt;
    // Start is called before the first frame update
    void Start()
    {
        ped.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ped.Stop();
            xpt.Play();
        }
    }
}
