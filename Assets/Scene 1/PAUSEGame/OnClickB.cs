using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickB : MonoBehaviour
{
    public GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CCbutton()
    {
        Time.timeScale = 1.0f;
        pause.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Scene1");
    }
}
