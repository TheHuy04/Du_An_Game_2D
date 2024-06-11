using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullTrap : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool daRoi = false;
    public Transform diemHoiPhuc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player3") && !daRoi)
        {
            rb.isKinematic = false;
            daRoi = true;
            Invoke("KhoiPhuc", 2f);
        }
    }
    private void KhoiPhuc()
    {
        rb.isKinematic=true;
        rb.velocity = Vector2.zero;
        rb.angularDrag = 0;
        transform.position = diemHoiPhuc.position;
        daRoi = false ;
    }


}
