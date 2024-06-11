using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
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
}
