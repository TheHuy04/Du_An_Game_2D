using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLV : MonoBehaviour
{
    public string tenManChoi;
    public void LoadManChoi()
    {
        SceneManager.LoadScene(tenManChoi);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player3"))
        {
            LoadManChoi();
        }

        
    }

}
