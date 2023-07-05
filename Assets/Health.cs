using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public bool isDead;

    public UnityEvent onDamaged;
    public UnityEvent onDeath;
    public virtual void TakeDamge(float damageAmount)
    {
        onDamaged.Invoke();
        currentHealth -= damageAmount;
        if(currentHealth <=0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        onDeath.Invoke();   
    }
}
