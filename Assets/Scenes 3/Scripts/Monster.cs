using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    public Animator anm;
    public int maxHeath = 3;
    public int attackDamage = 1;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    public Transform attackPoint;
    public LayerMask playerLayer;
    int currentHealth;

    private float nextAttackTime = 1.5f;
    public float moveSpeed = 2f;
    public float patrolRange = 5f;

    private Vector2 patrolCenter;
    private Vector2 patrolTarget;
    private bool movingRight = true;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHeath;
        patrolCenter = transform.position;
        SetPatrolTarget();
    }
    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        //anm
        anm.SetTrigger("TakeHit");
        if(currentHealth <= 0)
        {
            
            Die();
        }
    }
    private void Update()
    {
        Patrol();
        if (Time.time >= nextAttackTime)
        {
            Collider2D player = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);
            if (player != null)
            {       
                Attack(player.GetComponent<PlayerHealth>());
                nextAttackTime = Time.time + 2f / attackRate;
            }
        }
    }
    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolTarget, moveSpeed * Time.deltaTime);
        anm.SetBool("Running", true);
        if (Vector2.Distance(transform.position, patrolTarget) < 0.2f)
        {
            movingRight = !movingRight;
            SetPatrolTarget();
            Flip();
        }
    }
    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    void SetPatrolTarget()
    {
        float targetX = movingRight ? patrolCenter.x + patrolRange : patrolCenter.x - patrolRange;
        patrolTarget = new Vector2(targetX, transform.position.y);
    }
    void Attack(PlayerHealth playerHealth)
    {
        audioManager.PlaySFX(audioManager.attackClip);
        if (playerHealth != null)
        {
            anm.SetTrigger("Attack");
            playerHealth.TakeDamage(attackDamage);
        }
    }
    void Die()
    {
        anm.SetTrigger("Die");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio3").GetComponent<AudioManager>();
    }


}
