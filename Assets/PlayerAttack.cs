using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;

    [Header("Melee Attack Setting")]
    public GameObject meleeCollider;
    public float attackDelay;
    public float attackLifeTime;

    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponentInChildren<Animator>();
        meleeCollider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            anim.Play("Attack");
            Invoke("ActivateMeleeCollider", attackDelay);
        }
    }

    void ActivateMeleeCollider()
    {
        meleeCollider.SetActive(true);
        Invoke("DeactivateMeleeCollider", attackLifeTime);
    }
    
    void DeactivateMeleeCollider()
    {
        meleeCollider.SetActive(false);
    }
}
