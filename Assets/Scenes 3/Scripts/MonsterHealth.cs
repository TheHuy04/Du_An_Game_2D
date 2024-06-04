using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int maxHealth = 3; //[seri..] int max..
    int currentHealth;
    public PlayerHealth player; // Tham chiếu đến script PlayerHealth

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        player.AddScore(1); // Cộng điểm cho người chơi
        Destroy(gameObject); // Hủy đối tượng quái vật
    }
}
