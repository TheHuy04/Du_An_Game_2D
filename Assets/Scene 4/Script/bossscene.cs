using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossscene : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ccontinue()
    {
        Time.timeScale = 1.0f;
        panel.SetActive(false);
    }
    public void resst()
    {
        SceneManager.LoadScene("Scene4_HuyTran");
    }
}
