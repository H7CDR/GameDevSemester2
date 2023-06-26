using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using Unity.VisualScripting;

public class OnlineScoreManager : MonoBehaviour
{
    public PhotonView view;

    public int[] playerScore;
    public int[] playerCombo;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        playerScore = new int[PhotonNetwork.CurrentRoom.MaxPlayers];
        playerCombo = new int[PhotonNetwork.CurrentRoom.MaxPlayers];

    }
}
