using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum Player { Player1, Player2 };
    public Player currentPlayer;
    public KeyCode p1RockInput, p1PaperInput, p1ScissorsInput, p2RockInput, p2PaperInput, p2ScissorsInput;

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

    public bool isMultiplayer;

    private void Start()
    {
        //_PaperButtonPressed = false;
        _paperCollider = _paper.GetComponent<BoxCollider>();
        _rockCollider = _rock.GetComponent<BoxCollider>();
        _scissorsCollider = _scissors.GetComponent<BoxCollider>();

    }

    private void Update()
    {
        if (currentPlayer == Player.Player1)
        {
            if (Input.GetKeyDown(p1PaperInput))
            {
                _particle.Play();
                Debug.Log("Paper!");
                //_PaperButtonPressed = true;
                _paperCollider.enabled = true;
                _tapKick.Play();
            }
            else if (Input.GetKeyUp(p1PaperInput))
            {
                //_PaperButtonPressed = false;
                _paperCollider.enabled = false;
            }
            if (Input.GetKeyDown(p1RockInput))
            {
                _particle.Play();
                Debug.Log("ROCK!");
                _rockCollider.enabled = true;
                _tapKick.Play();
            }
            else if (Input.GetKeyUp(p1RockInput))
            {
                _rockCollider.enabled = false;
            }
            if (Input.GetKeyDown(p1ScissorsInput))
            {
                _particle.Play();
                Debug.Log("Scissors!");
                _scissorsCollider.enabled = true;
                _tapKick.Play();
            }
            else if (Input.GetKeyUp(p1ScissorsInput))
            {
                _scissorsCollider.enabled = false;
            }
        }

        if (currentPlayer == Player.Player2)
        {
            if (Input.GetKeyDown(p2PaperInput))
            {
                _particle.Play();
                Debug.Log("Paper!");
                //_PaperButtonPressed = true;
                _paperCollider.enabled = true;
                _tapKick.Play();
            }
            else if (Input.GetKeyUp(p2PaperInput))
            {
                //_PaperButtonPressed = false;
                _paperCollider.enabled = false;
            }
            if (Input.GetKeyDown(p2RockInput))
            {
                _particle.Play();
                Debug.Log("ROCK!");
                _rockCollider.enabled = true;
                _tapKick.Play();
            }
            else if (Input.GetKeyUp(p2RockInput))
            {
                _rockCollider.enabled = false;
            }
            if (Input.GetKeyDown(p2ScissorsInput))
            {
                _particle.Play();
                Debug.Log("Scissors!");
                _scissorsCollider.enabled = true;
                _tapKick.Play();
            }
            else if (Input.GetKeyUp(p2ScissorsInput))
            {
                _scissorsCollider.enabled = false;
            }
        }
    }

}
