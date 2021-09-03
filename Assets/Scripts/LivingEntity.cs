using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth = 10;
    protected float health = 10;
    protected bool dead = false;
 
    public virtual void Start()
    {
        health = startingHealth;
    }
    public void TakeHit(float damage, RaycastHit hit)
    {
        health -= damage;
        if(health <= 0 && !dead)
        {
            Die();
        }
    }

    public void Die()
    {
        dead = true;
        Destroy(gameObject);
    }
}
