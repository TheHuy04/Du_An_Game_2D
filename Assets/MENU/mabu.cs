using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mabu : MonoBehaviour
{
    public GameObject panel;
    public float bar = 0f;
    public Slider slider;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bar == 100)
        {
            SceneManager.LoadScene("Scene1");
        }
    }
    public void openomega()
    {
        panel.SetActive(true);
        StartCoroutine(loadingbar());
    }
    IEnumerator loadingbar()
    {
        while (bar < 100)
        {
            bar += 1f;
            text.text = "Loading " + bar + "%";
            slider.value = bar;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
