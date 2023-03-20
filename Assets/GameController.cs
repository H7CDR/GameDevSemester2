using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Rock"))
        {
            if (Input.GetKeyDown(KeyCode.P)) 
            {
                Destroy(other.gameObject);
                _particle.Play();

            }
        }
    }
}
