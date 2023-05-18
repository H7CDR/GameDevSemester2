using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    #region Fields;
    public TMP_InputField joinRoomName;
    public TMP_InputField createRoomName;
    public TMP_Text errorLog;
    public byte maxPlayerPerRoom = 2;
    #endregion

    #region public function
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomName.text);
    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomName.text , new RoomOptions { MaxPlayers = maxPlayerPerRoom});
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);

    }
    #endregion

    #region pun callbacks
   
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        string errorMessage = "Faied to Join Room. Error: " + message;
        Debug.Log(errorMessage);
        errorLog.text = errorMessage;
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("WaitingForPlayers");
    }
    #endregion
}
