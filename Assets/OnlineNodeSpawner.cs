using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine.Pool;

public class OnlineNodeSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject _sphere;
    [SerializeField]
    GameObject _paper;
    [SerializeField]
    GameObject _scissors;
    [SerializeField]
    GameObject[] _spawnables;
    public float _spawnInterval;
    float _timer;
    public float _CountDownTimer;
    [SerializeField]
    float _bpm;
    [SerializeField]
    Transform[] _spawnPoint;


    private PhotonView view;

    //Define the photon event
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!view.IsMine) return;

        if (_CountDownTimer >=0)
        {
            _CountDownTimer -= Time.deltaTime;  
        }
        else
        {
            if (_timer >= _spawnInterval)
            {
                _timer = 0;
                view.RPC("spawnRandom", RpcTarget.All);
            }
            else
            {
                _timer += Time.deltaTime;
            }
        }
    }


    public void SpawnRock()
    {
        int a = PhotonNetwork.LocalPlayer.ActorNumber - 1;
        PhotonNetwork.Instantiate(_sphere.name, _spawnPoint[a].position, Quaternion.identity);
    }

    public void SpawnPaper()
    {
        int a = PhotonNetwork.LocalPlayer.ActorNumber - 1;
        PhotonNetwork.Instantiate(_paper.name, _spawnPoint[a].position, Quaternion.identity);
    }    

    public void SpawnScissors()
    {
        int a = PhotonNetwork.LocalPlayer.ActorNumber - 1;
        PhotonNetwork.Instantiate(_scissors.name, _spawnPoint[a].position, Quaternion.identity);
    }

    [PunRPC]
    public void spawnRandom()
    {
        int a = PhotonNetwork.LocalPlayer.ActorNumber - 1;
        Debug.Log(a);
        PhotonNetwork.Instantiate(_spawnables[Random.Range(0, 3)].name, _spawnPoint[a].position, Quaternion.identity);

    }

}
