using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreKeeper : MonoBehaviour
{
    public Player4 pl;
    public int diemhientai = 0;
    public Text cointext;
    public GameObject panel;
    public float ki = 0f;
    void Start()
    {
        pl = FindObjectOfType<Player4>();
    }
    void Update()
    {
        if(pl.hpslider <= 0)
        {
            ki += 1f;
            if(ki == 500)
            {
                panel.SetActive(true);
                pl.hpslider += 1f;
            }
        }

    }
    public void tangdiem(int amount)
    {
        diemhientai += amount;
        cointext.text = diemhientai + " Coin";
    }
    public void trudiem(int amount)
    {
        diemhientai -= amount;
        cointext.text = diemhientai + " Coin";
    }
}
