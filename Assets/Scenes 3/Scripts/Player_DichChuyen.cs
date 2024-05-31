using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_DichChuyen : MonoBehaviour
{
    [SerializeField] GameObject Cong;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Cong != null)
        {
            transform.position = Cong.GetComponent<Cong>().getDiemDichChuyen().position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cong"))
        {
            Cong = collision.gameObject;
        }   
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cong"))
        {
            Cong = null;
        }
    }
}
