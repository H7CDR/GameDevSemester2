using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks
{

    #region Serialiazble fields

    #endregion

    #region private fields

    //this is teh client version number
    string gameVersion = "1";
    #endregion

    #region Monobehaviour callbacks
    void Awake()
    {
        //CRITCAL LINE OF CODES
        //MAKE SURE EVERYONES SCENE ARE SYNCHED WHEN loadLevel is called
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // on start, try to connect to the master server.
    private void Start()
    {
        Connect();
    }

    #endregion

    #region public Methods

    public void Connect()
    {
        if(PhotonNetwork.IsConnected)
        {
            //Attempt to join Lobby
            PhotonNetwork.JoinLobby();
        }
        else
        {
            //attempt to connect using server setting, then set your game version
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion= gameVersion;
        }
    }
    #endregion

    #region Pun Callbacks
    public override void OnConnectedToMaster()
    {
        Debug.Log("Successfully connected to Server. Attempting to join a lobby");
        PhotonNetwork.JoinLobby();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("Failed to connect, OnDisconnected was called with the reason {0}", cause);
        SceneManager.LoadScene(0);
    }
    public override void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel("CreateOrJoinRoom");
    }
    #endregion
}
