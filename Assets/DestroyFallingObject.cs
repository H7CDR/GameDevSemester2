using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyFallingObject : MonoBehaviour
{
    public UnityEvent ontriggerEvent;
    [SerializeField]
    HealthUI healthUIScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameEnder"))
        {
            healthUIScript.Die();
            Debug.Log("GameEnd");
        }
        else
        {
            healthUIScript.TakeDamge(2);
            Destroy(other.gameObject);
            ontriggerEvent.Invoke();
        }
    }
}
