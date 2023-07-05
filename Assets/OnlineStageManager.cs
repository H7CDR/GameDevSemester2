using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;

public class OnlineStageManager : MonoBehaviour
{
    public OnlineHealthUI[] playerHealth;
    public AudioSource _sound;

    [SerializeField]
    OnlineGameController _p1ControllerScript;

    public int[] player1Score;
    public int[] p1ComboCount;
    [Header("UI")]
    public CanvasGroup p1GameOverCanvas, p2GameOverCanvas, allGameOverScreen;
    public CanvasGroup p1PausedScreen;

    private string winningText;
    [SerializeField]
    TextMeshProUGUI declareWinnerTxt;

    [Header("Scoring Setting")]
    public int scPerfect;
    public int scOkay;
    public int scMissed;
    public int scPass;

    public bool[] playerDeath;
    [SerializeField]
    GameObject _p1NodeKiller,_p2NodeKiller;

    [Header("Players")]
    public GameObject[] players;
    public GameObject[] playerPrefabs;
    public Transform[] playerSpawns;

    private PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        playerDeath = new bool[PhotonNetwork.CurrentRoom.MaxPlayers];
        player1Score = new int[PhotonNetwork.CurrentRoom.MaxPlayers];
        p1ComboCount = new int[PhotonNetwork.CurrentRoom.MaxPlayers]; 
        Invoke("spawnPlayerAtStart", 1);
    }

    void spawnPlayerAtStart()
    {
        //SpawnPlayer
        int a = PhotonNetwork.LocalPlayer.ActorNumber - 1;
        GameObject player = PhotonNetwork.Instantiate(playerPrefabs[a].name, playerSpawns[a].position, Quaternion.Euler(new Vector3(0, -37.263f,90)));
        if (player == null)
        {
            Debug.Log("No Player Reference");
        }
        Invoke("CallAddPlayerToList", 1.5f);
    }

    void CallAddPlayerToList()
    {
        view.RPC("AddPlayerToList", RpcTarget.All);
        view.RPC("AddingPlayerHealthToList",RpcTarget.All);
    }

    [PunRPC] void AddPlayerToList() //Find all instance of players and add them to the array;
    {
        GameObject[] playerFound = GameObject.FindGameObjectsWithTag("Player");//Find the objects
        Debug.Log(playerFound.ToString());
        foreach (GameObject player in playerFound) //itterate through them
        {
            int playerNum = player.GetComponent<PhotonView>().OwnerActorNr - 1;// Get the object player number
            players[playerNum] = player;//Assign the object to the correct slot;
        }
    }
    [PunRPC]
    void AddingPlayerHealthToList()
    {
        foreach(GameObject player in players)
        {
            int playerNum = player.GetComponent<PhotonView>().OwnerActorNr - 1;
            playerHealth[playerNum] = player.GetComponent<OnlineHealthUI>();
        }

    }

    void addingPlayerScoreToList()
    {
        foreach(GameObject player in players)
        {
            int playerNum = player.GetComponent<PhotonView>().OwnerActorNr - 1;
            player1Score[playerNum] = player.GetComponentInChildren<OnlineScoreUI>().playerScore;
        }
    }
    
    private void Update()
    {
        if (allPlayerDead() ==false)
        {
            return;
        }
        view.RPC("allGameOver", RpcTarget.All);
    }

    [PunRPC]
    void currentPlayerDead()
    {
        playerDeath[PhotonNetwork.LocalPlayer.ActorNumber - 1] = true;
    }

    [PunRPC]
    bool allPlayerDead()
    {
        foreach(bool item in playerDeath)
        {
            if (item == false) return false;
        }
        return true;
    }

    [PunRPC]
    void allGameOver()
    {
        //freezeGame();
        allGameOverScreen.gameObject.SetActive(true);
        addingPlayerScoreToList();
        compareScore();
    }

    void freezeGame()
    {
        Time.timeScale = 0;
    }
    void slowGame()
    {
        Time.timeScale = 0.2f;
    }

    void compareScore()
    {
        if (player1Score[0] > player1Score[1])
        {
            declareWinnerTxt.text ="Player 1 WIN!<br>" + "\n" + player1Score[0] +  "  >  " + player1Score[1];
        }
        else if (player1Score[0] < player1Score[1])
        {
            declareWinnerTxt.text = "Player 2 WIN!<br>" + "\n" + player1Score[0] + "  <  " + player1Score[1];
        }
    }

    public void PlayerDeath(int playerNum)
    {
        bool anyAlive = false;
        foreach(GameObject player in players)
        {
            if(player.GetComponent<OnlineHealthUI>().isDead == false)
            {
                anyAlive = true;
            }

        }
        if(anyAlive == false)
        {
            Debug.Log("NO ONE IS ALIVE");
            allGameOver();
        }
    }


}
