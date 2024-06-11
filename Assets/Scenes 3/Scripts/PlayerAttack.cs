using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anm;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask MonsterLayers;
    public int attackDamage = 1;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }
    void Attack()
    {
        anm.SetTrigger("Attack");
        Collider2D[] hitMonster = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, MonsterLayers);

        foreach(Collider2D monsterr in hitMonster)
        {
            MonsterHealth monsterHealth = monsterr.GetComponent<MonsterHealth>();
            if (monsterHealth != null)
            {
                monsterHealth.TakeDamage(attackDamage);
            }
        }   
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return; 
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
