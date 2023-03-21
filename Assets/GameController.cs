using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _particle;
    [SerializeField]
    AudioSource _tapKick;
    [SerializeField]
    AudioSource _pressedWrong;
    private Collider _paperCollider;
    private Collider _rockCollider;
    private Collider _scissorsCollider;

    private void Start()
    {
        //_PaperButtonPressed = false;
        _paperCollider = gameObject.GetComponent<BoxCollider>();
        _rockCollider = gameObject.GetComponent<SphereCollider>();
        _scissorsCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            _particle.Play();
            Debug.Log("Paper!");
            //_PaperButtonPressed = true;
            _paperCollider.enabled = true;
            _tapKick.Play();
        }
        else if (Input.GetKeyUp(KeyCode.O))
        {
            //_PaperButtonPressed = false;
            _paperCollider.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            _particle.Play();
            Debug.Log("ROCK!");
            _rockCollider.enabled = true;
            _tapKick.Play();
        }
        else if (Input.GetKeyUp(KeyCode.I))
        {
            _rockCollider.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            _particle.Play();
            Debug.Log("Scissors!");
            _scissorsCollider.enabled = true;
            _tapKick.Play();
        }
        else if(Input.GetKeyUp(KeyCode.P))
        {
            _scissorsCollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.GetComponent<Collider>().ToString());
        if (other.CompareTag("Rock"))
        {
            //Destroy(other.gameObject);
            //Debug.Log("Paper beat rocks");
        }
        if (other.CompareTag("Paper"))
        {
            //Destroy(other.gameObject);
            _pressedWrong.Play();
        }
    }

}
