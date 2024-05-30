using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cong : MonoBehaviour
{
    [SerializeField] Transform diemDichChuyen;
    public Transform getDiemDichChuyen()
    {
        return diemDichChuyen;
    }
}
