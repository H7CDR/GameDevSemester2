using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    float seqAttackTimer;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponentInChildren<Animator>();
        seqAttackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.J) && seqAttackTimer == 0) 
        {
            seqAttackTimer += 1;
            anim.Play("Attack");
            
        }
        if(Input.GetKey(KeyCode.J) && seqAttackTimer == 1)
        {
            seqAttackTimer = 0;
            anim.SetInteger("AttkSeq", 1);
        }

    }
}
