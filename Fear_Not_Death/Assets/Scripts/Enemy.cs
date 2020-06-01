using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    public AIPath aiPath;
    void Start()
        {
            currentHealth = maxHealth;
        }

    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(3f, 2.5f, 1f);
        } else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-3f, 2.5f, 1f);
        }
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <=0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
