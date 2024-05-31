using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public int speed = 1;
    public Transform diemBatDau;
    public Transform diemKetThuc;
    private Vector2 diemMucTieu;

    // Start is called before the first frame update
    void Start()
    {
        diemMucTieu = diemBatDau.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, diemBatDau.position) < 0.1f) 
        {
            diemMucTieu = diemKetThuc.position;
        }
        if(Vector2.Distance(transform.position, diemKetThuc.position) < 0.1f)
        {
            diemMucTieu = diemBatDau.position;
        }
        transform.position  =Vector2.MoveTowards(transform.position,diemMucTieu,speed * Time.deltaTime);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player3"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player3"))
        {
            collision.transform.SetParent(null);
        }
    }
}
