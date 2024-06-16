using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Animator anm;
    [SerializeField] int maxHealth;
    int currentHealth; //mau hien tai
    public HP healthBar;
    private Rigidbody2D rb;
    

    public UnityEvent OnDeath;

    private int score = 0;
    public TextMeshProUGUI ScoreText;

    private AudioManager audioManager;

    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }
    private void OnDisable()
    {
        OnDeath.RemoveListener(Death);
    }

    private void Start()
    {
        
        anm = GetComponent<Animator>(); 
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
        UpdateScoreText(); //cap nhat diem
    }

    //bi danh se ntn
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeath.Invoke();
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
    }
    public void Death()
    {
        

        anm.SetTrigger("Die");
        StartCoroutine(WaitForAnimation());
    }
    private IEnumerator WaitForAnimation()
    {
        
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText(); // cap nhat diem
    }
    private void UpdateScoreText()
    {
        if (ScoreText != null)
        {
            ScoreText.text = " " + score;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin3"))
        {
            CollectCoin(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Trap3")) // Ktra bay
        {
            TakeDamage(1); // gay 1 dmg khi cham bay
        }
        else if (other.gameObject.CompareTag("Water"))
        {
            TakeDamage(1000);
        }

    }   

    private void CollectCoin(GameObject coin)
    {
        audioManager.PlaySFX(audioManager.coinClip);
        Destroy(coin); 
        AddScore(1); 
    }
    public void Heal(int amount)
    {
        audioManager.PlaySFX(audioManager.Health);
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        healthBar.UpdateBar(currentHealth, maxHealth);
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio3").GetComponent<AudioManager>();
    }



}
