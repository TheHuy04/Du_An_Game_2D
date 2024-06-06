using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTrap : MonoBehaviour
{
    public float toDoXoay = 5;
    public float tocDo;
    public Transform diemA;
    public Transform diemB;
    private Vector3 diemMucTieu;

    // Start is called before the first frame update
    void Start()
    {
        diemMucTieu = diemA.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, diemMucTieu, tocDo * Time.deltaTime);
        if (Vector3.Distance(transform.position, diemMucTieu) < 0.1f)
        {
            if (transform.position == diemA.position)
            {
                diemMucTieu = diemB.position;
            }
            else
            {
                diemMucTieu = diemA.position;
            }
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, toDoXoay);
    }
}