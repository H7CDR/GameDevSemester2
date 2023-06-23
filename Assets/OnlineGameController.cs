using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnlineGameController : MonoBehaviour
{
    public KeyCode p1PaperInput, p1RockInput, p1ScissorsInput;

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

    [Header("OnlineFunctions")]
    PhotonView view;


    private void Start()
    {
        //_PaperButtonPressed = false;
        _paperCollider = _paper.GetComponent<BoxCollider>();
        _rockCollider = _rock.GetComponent<BoxCollider>();
        _scissorsCollider = _scissors.GetComponent<BoxCollider>();
        view = GetComponent<PhotonView>();

    }

    private void Update()
    {
        if (!view.IsMine) return;
        if (Input.GetKeyDown(p1PaperInput))
        {
            view.RPC("PlayParticle", RpcTarget.All);
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
            view.RPC("PlayParticle", RpcTarget.All);
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
            view.RPC("PlayParticle", RpcTarget.All);
            Debug.Log("Scissors!");
                _scissorsCollider.enabled = true;
                _tapKick.Play();
            }
            else if (Input.GetKeyUp(p1ScissorsInput))
            {
                _scissorsCollider.enabled = false;
            }
        /*if (currentPlayer == Player.Player2)
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
        }*/
    }

    [PunRPC]
    void PlayParticle()
    {
        _particle.Play();
    }

}
