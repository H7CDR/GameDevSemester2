using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthWithArmour : HealthUI
{
    public float armour;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public override void TakeDamge(float damageAmount)
    {
        if (armour >0)
        {
            armour -= damageAmount;
            damageAmount *= 0.7f;
        }
        base.TakeDamge(damageAmount);
    }
}
