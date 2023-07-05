using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.Simple;

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
        playersReady = new bool[PhotonNetwork.CurrentRoom.MaxPlayers];
        PhotonNetwork.LocalPlayer.NickName = "Player" + PhotonNetwork.LocalPlayer.ActorNumber;
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;

        numberOfPlayer.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + " / " + PhotonNetwork.CurrentRoom.MaxPlayers.ToString();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        numberOfPlayer.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + " / " + PhotonNetwork.CurrentRoom.MaxPlayers.ToString();
        Invoke("UpdateBoolsOnJoin", 1);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        numberOfPlayer.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + " / " + PhotonNetwork.CurrentRoom.MaxPlayers.ToString();
        view.RPC("ReadyPlayer", RpcTarget.All, otherPlayer.ActorNumber, false);
    }

    public void UpdateName()
    {
        PhotonNetwork.LocalPlayer.NickName = playerName.text;
    }

    public void ReturnToMenu()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);
    }

    public void LoadLevel()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            messages.text = "You are not the Host, you cannot do that!";
        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount < PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            messages.text = "Waiting for other player to join lobby";
        }
        else if (AllPlayerReady() == false)
        {
            messages.text = "Waiting for other player to be ready";
        }
        else
        {
            SceneManager.LoadScene(levelName);
        }
    }

    bool AllPlayerReady()
    {
        foreach (bool item in playersReady)
        {
            if (item == false) return false;

        }
        return true;
    }

    [PunRPC]
    public void ReadyPlayer(int playerNumber, bool isReady)
    {
        playersReady[playerNumber - 1] = isReady;
    }

    public void RunReadyPlayer(bool isReady)
    {
        view.RPC("ReadyPlayer", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber, isReady);
    }

    private void UpdateBoolsOnJoin()
    {
        int playerNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        bool isReady = playersReady[PhotonNetwork.LocalPlayer.ActorNumber - 1];

        view.RPC("ReadyPlayer", RpcTarget.All, playerNumber, isReady);
    }


}
