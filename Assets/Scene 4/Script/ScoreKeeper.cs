using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public int diemhientai = 0;
    public Text cointext;
    // Start is called before the first frame update
    void Start()
    {
        cointext.text = diemhientai + " Coin";
    }
    public void tangdiem(int amount)
    {
        diemhientai += amount;
        cointext.text = diemhientai + " Coin";
    }
}
