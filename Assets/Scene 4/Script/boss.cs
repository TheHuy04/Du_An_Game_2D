using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    public float skill = 0f, count = 5f;
    public Animator ani;
    public GameObject chieu1, chieu2, chieu3;
    public Transform chieum1, chieuh2, chieub3;
    public float healthslider = 100f;
    public Slider bossslider;
    public int point = 99;
    public ScoreKeeper Keeper;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        StartCoroutine(loadskill());
        Keeper = FindObjectOfType<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthslider <= 0)
        {
            ani.SetBool("chet",true);
            Destroy(this.gameObject,2f);
            Keeper.tangdiem(point);
        }
        if (skill == 1f)
        {
            ani.SetBool("chieumot",true);
            GameObject go = Instantiate(chieu1, chieum1.position, chieum1.rotation);
            Rigidbody2D c1 = go.GetComponent<Rigidbody2D>();
            c1.AddForce(chieum1.right * 10f *Mathf.Sign(transform.localScale.x),ForceMode2D.Impulse);
            Destroy(c1.gameObject, 3f);
        }
        else if(skill == 2f)
        {
            ani.SetBool("chieumot",false);
        }
        else if(skill == 3f)
        {
            ani.SetBool("chieuhai", true);
            GameObject go2 = Instantiate(chieu2, chieuh2.position, chieuh2.rotation);
            Rigidbody2D c2 = go2.GetComponent<Rigidbody2D>();
            c2.AddForce(chieuh2.right * 10f *Mathf.Sign(transform.localScale.x),ForceMode2D.Impulse);
            Destroy(c2.gameObject, 3f);
        }
        else if(skill == 4f)
        {
            ani.SetBool("chieuhai",false );
        }
        else if(skill == 5f)
        {
            if(count -- > 0f)
            {
                ani.SetBool("chieuba", true);
                GameObject go3 = Instantiate(chieu3, chieub3.position, Quaternion.identity);
            }
        }
        else if(skill == 0f)
        {
            ani.SetBool("chieuba", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            healthslider -= 5f;
            bossslider.value = healthslider;
        }
    }
    IEnumerator loadskill()
    {
        while (skill == 0f)
        {
            skill += 1f;
            yield return new WaitForSeconds(1f);
            while (skill == 1f)
            {
                skill += 1f;
                yield return new WaitForSeconds(5f);
                while (skill == 2f)
                {
                    skill += 1f;
                    yield return new WaitForSeconds(1f);
                    while (skill == 3f)
                    {
                        skill += 1f;
                        yield return new WaitForSeconds(5f);
                        while (skill == 4f)
                        {
                            skill += 1f;
                            yield return new WaitForSeconds(1f);
                            while (skill == 5f)
                            {
                                skill -= 5f;
                                yield return new WaitForSeconds(10f);
                            }
                        }
                    }
                }
            }
        }
    }
}
