using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int healAmount = 1; // Số lượng máu được hồi khi nhặt trái tim

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player3"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount); // Gọi phương thức Heal trong PlayerHealth để hồi máu
                Destroy(gameObject); // Hủy đối tượng trái tim sau khi nhặt được
            }
        }
    }
}
