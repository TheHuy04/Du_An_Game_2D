using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject panel,panels, button;
    public Player4 player;
    public ScoreKeeper scoreKeeper;
    public Slider slider;
    public int trudiemnhe = 2, trudiemnha = 20;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player4>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playagain()
    {
        SceneManager.LoadScene("Scene4_HuyTran");
        Time.timeScale = 1.0f;
    }
    public void ccontinue()
    {
        panel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void shopfill()
    {
        Time.timeScale = 0f;
        panels.SetActive(true);
    }
    public void addhp()
    {
            if (scoreKeeper.diemhientai >= 2 && player.hpslider < 100)
            {
                player.hpslider += 50f;
                slider.value = player.hpslider;
                scoreKeeper.trudiem(trudiemnhe);
            }
            if(player.hpslider > 100)
        {
            player.hpslider = 100f;
        }
    }
    public void thembot()
    {
        if (scoreKeeper.diemhientai >= 20)
        {
            player.skill(1);
            slider.value = player.hpslider;
            scoreKeeper.trudiem(trudiemnha);
        }
    }
    public void backgame()
    {
        Time.timeScale = 1f;
        panels.SetActive(false);
    }
}
