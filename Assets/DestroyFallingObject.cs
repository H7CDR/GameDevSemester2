using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFallingObject : MonoBehaviour
{
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
        healthUIScript.TakeDamge(2);
        Destroy(other.gameObject);
    }
}
