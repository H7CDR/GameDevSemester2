using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : Health
{
    public Slider healthBar;
    public Image healthIcon;

    void Start()
    {
        if (healthBar)
        {
            healthBar.maxValue = maxHealth;
        }
    }
    public override void TakeDamge(float damageAmount)
    {
        base.TakeDamge(damageAmount); 
        updateUI();
    }

    void updateUI()
    {
        if(healthBar)
        {
            {
                healthBar.value = currentHealth;
            }
        }
        else if (healthIcon)
        {
            healthIcon.fillAmount = currentHealth / maxHealth;
        }
    }

}
