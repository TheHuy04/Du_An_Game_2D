using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    // Start is called before the first frame update
    public Image hp;
    public void CapNhatHP(float HPHT, float LMTD)//luong mau hien tai && luog mau  toi da
    {
        hp.fillAmount = HPHT/LMTD;
    }
}
