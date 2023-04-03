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
    [SerializeField]
    GameObject _rock, _paper, _scissors;

    private void Start()
    {
        //_PaperButtonPressed = false;
        _paperCollider = _paper.GetComponent<BoxCollider>();
        _rockCollider = _rock.GetComponent<BoxCollider>();
        _scissorsCollider = _scissors.GetComponent<BoxCollider>();
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

}
