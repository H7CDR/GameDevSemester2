using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _particle;
    [SerializeField]
    bool _PaperButtonPressed;

    private void Start()
    {
        _PaperButtonPressed = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _particle.Play();
            Debug.Log("P is pressed");
            _PaperButtonPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.P))
        {
            _PaperButtonPressed = false;
        }
        else
        {
            Invoke("PaperBoolOff", 1f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Rock")&& _PaperButtonPressed == true)
        {
            Destroy(other.gameObject);
            Debug.Log("Paper beat rocks"); 
        }

    }

    private void PaperBoolOff()
    {
        _PaperButtonPressed = false;
    }
}
