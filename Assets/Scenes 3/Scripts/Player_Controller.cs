


using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class Player3 : MonoBehaviour
{
    public float speed;
    public float jumForce;
    private Rigidbody2D rb;
    private bool nhay1L;
    private Animator anm;
    public GameObject arrowPrefab;
    public Transform bowPos;

    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //di chuyen
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
            transform.localScale = new Vector3(1f, 1f, 1f);
            anm.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 5f * Time.deltaTime);
            transform.localScale = new Vector3(-1f, 1f, 1f);
            anm.SetBool("isRunning", true);
        }else anm.SetBool("isRunning", false);

        if (Input.GetKeyDown(KeyCode.Space) && nhay1L)
        {
            rb.AddForce(Vector2.up * jumForce, ForceMode2D.Impulse);
            nhay1L = false;
            anm.SetBool("isJumping", true);
        }
        if(Input.GetMouseButtonDown(0) )
        {
            shoot();
        }

    }
    public void shoot()
    {
        GameObject arr = Instantiate(arrowPrefab, bowPos.position, bowPos.rotation);
        Rigidbody2D rb = arr.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.right * 50f * Mathf.Sign(transform.localScale.x), ForceMode2D.Impulse);
        Destroy(rb.gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            nhay1L = true;
        }
    }   
}
