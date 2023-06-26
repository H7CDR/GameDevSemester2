using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class OnlineHealthUI : Health
{
    public Slider healthBar;
    public Image healthIcon;
    private PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();
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
        if (healthBar)
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
