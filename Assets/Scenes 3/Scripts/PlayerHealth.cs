using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    private Animator anm;
    [SerializeField] int maxHealth;
    int currentHealth; //mau hien tai
    public HP healthBar;

    public UnityEvent OnDeath;

    private int score = 0;
    public TextMeshProUGUI ScoreText;

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
        anm = GetComponent<Animator>(); // Lấy thành phần Animator
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
        UpdateScoreText(); // Cập nhật điểm số ban đầu
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster3"))
        {
            GetComponent<PlayerHealth>().TakeDamage(1);
        }
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
        // Giả sử Animation "Die" kéo dài khoảng 1 giây, bạn có thể điều chỉnh thời gian này
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText(); // Cập nhật điểm số trên màn hình
    }
    private void UpdateScoreText()
    {
        if (ScoreText != null)
        {
            ScoreText.text = "Score: " + score;
        }
    }
}
