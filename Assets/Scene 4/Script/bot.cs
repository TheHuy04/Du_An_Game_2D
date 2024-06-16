using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{
    public float hp = 100f;
    public float timfor = 0f;
    public GameObject sung;
    public Transform hom;
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shootte());
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
           Destroy(this.gameObject);
        }
        if (timfor == 1f)
        {
            GameObject shoot = Instantiate(sung, hom.position, hom.rotation);
            Rigidbody2D body = shoot.GetComponent<Rigidbody2D>();
            body.AddForce(hom.right * 20f, ForceMode2D.Impulse);
            Destroy(body.gameObject,2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bossfire") || collision.CompareTag("Enemys"))
        {
            hp -= 0.1f;
        }
    }
    IEnumerator shootte()
    {
        while(timfor == 0f)
        {
            timfor += 1f;
            yield return new WaitForSeconds(0.005f);
            while(timfor == 1f)
            {
                timfor -= 1f;
                yield return new WaitForSeconds(2f);
            }
        }
    }
}
