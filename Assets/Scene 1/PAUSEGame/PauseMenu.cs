using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPause;
    public Button Resume;
    public Button Restart;

    void Start()
    {

        pauseMenu.SetActive(false);

        Resume.onClick.AddListener(ResumeGame);

        Restart.onClick.AddListener(RestartGame);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }
    private void RestartGame()
    {
        SceneManager.LoadScene("Scene1");
        Time.timeScale = 1;
    }

}



