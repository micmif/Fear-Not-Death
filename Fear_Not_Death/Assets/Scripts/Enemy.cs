using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public int maxHealth = 100;
    int currentHealth;
    public AIPath aiPath;
    void Start()
        {
            currentHealth = maxHealth;
        }

    void Update()
    {
        if(aiPath.desiredVelocity.x != 0)
        {
            anim.SetBool("isWalking", true);
        } else {
            anim.SetBool("isWalking", false); 
        }

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

        anim.SetTrigger("Hurt");

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
