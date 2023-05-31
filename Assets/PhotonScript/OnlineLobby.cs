using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;


public class OnlineLobby : MonoBehaviourPunCallbacks
{
    public bool[] playersReady;

    public PhotonView view;

    public TMP_Text roomName;
    public TMP_Text messages;
    public TMP_Text numberOfPlayer;
    public TMP_InputField playerName;

    public string levelName;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.LocalPlayer.NickName = "Player" + PhotonNetwork.LocalPlayer.ActorNumber;
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;

        numberOfPlayer.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + " / "+ PhotonNetwork.CurrentRoom.MaxPlayers.ToString();
    }

    public void UpdateName()
    {
        PhotonNetwork.LocalPlayer.NickName = playerName.text;
    }


    public void LoadLevel()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            SceneManager.LoadScene(levelName);
        }
        else
        {
            messages.text = "You are not the Host, you cannot do that!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
