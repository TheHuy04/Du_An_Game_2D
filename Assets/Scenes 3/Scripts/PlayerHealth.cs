using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    private Animator anm;
    [SerializeField] int maxHealth;
    int currentHealth; //mau hien tai
    public HP healthBar;

    public UnityEvent OnDeath;

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
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth,maxHealth);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
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
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeath.Invoke();   
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
    }
    public void Death()
    {
        Destroy(gameObject);
        anm.SetTrigger("Die");
    }
}
