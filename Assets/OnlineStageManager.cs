using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;

public class OnlineStageManager : MonoBehaviour
{
    public Health player1Health;
    public ScoreManagerScript scoreManagerScript;
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

    public bool _player1GameOver, _player2GameOver, player1Win, player2Win;
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
       _player1GameOver = false;
        player1Win = false;

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
    void AddScriptToManager()
    {
        player1Health = players[PhotonNetwork.LocalPlayer.ActorNumber - 1].GetComponent<HealthUI>();
        _p1ControllerScript = players[PhotonNetwork.LocalPlayer.ActorNumber - 1].GetComponent<OnlineGameController>();

    }
    
    private void Update()
    {
        if (_player1GameOver && _player2GameOver) 
        {
            Time.timeScale = 0f;
            //allGameOver();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused();
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _sound.GetComponent<AudioSource>().Play();
    }
    public void P1GameOver()
    {
        p1GameOverCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        _sound.GetComponent<AudioSource>().Stop();
    }

    public void Player1GameOver()
    {
        p1GameOverCanvas.gameObject.SetActive(true);
        _p1ControllerScript.gameObject.SetActive(false);
        SaveP1Score();
        _player1GameOver = true;
        //_p1NodeKiller.gameObject.SetActive(false);
    }
    /*public void Player2GameOver()
    {
        p2GameOverCanvas.gameObject.SetActive(true);
        _p2ControllerScript.gameObject.SetActive(false);
        SaveP2Score();
        _player2GameOver = true;
        _p2NodeKiller.gameObject.SetActive(false);
    }*/
   /* public void allGameOver()
    {
        p1GameOverCanvas.gameObject.SetActive(false);
        p2GameOverCanvas.gameObject.SetActive(false);
        _p1ControllerScript.gameObject.SetActive(true);
        _p2ControllerScript.gameObject.SetActive(true);
        allGameOverScreen.gameObject.SetActive(true);
        compareScore();
        _sound.Stop();
        declareWinnerTxt.text = winningText + "P1: " + player1Score + ".     " + "P2: " + player2Score +"." ;

    }*/

    public void gamePaused()
    {
        p1PausedScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
        _sound.GetComponent<AudioSource>().Pause();
    }

    /*public void SaveP1Score()
    {
        GameMaster.instance.saveData.player1Scores.Add(player1Score);
        GameMaster.instance.saveData.player1Scores.Sort(SortFunc);
        SaveSystemScript.instance.SaveGame(GameMaster.instance.saveData);
        Debug.Log("Data Save");
    }*/

    /*public void SaveP2Score()
    {
        GameMaster.instance.saveData.player2Scores.Add(player2Score);
        GameMaster.instance.saveData.player2Scores.Sort(SortFunc);
        SaveSystemScript.instance.SaveGame(GameMaster.instance.saveData);
    }*/

    int SortFunc(int a, int b)
    {
        if (a < b)
        {
            return +1;
        }
        if (a > b)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public void resetScore()
    {
        GameMaster.instance.saveData.player1Scores.Clear();
        SaveSystemScript.instance.SaveGame(GameMaster.instance.saveData);
    }

    /*public void compareScore()
    {
        if (player1Score > player2Score)
        {
            player1Win = true;
            player2Win = false;
            winningText = "PLAYER 1 WINS. </b>";
        }
        if (player2Score > player1Score)
        {
            player2Win = true;
            player1Win = false;
            winningText = "PLAYER 2 WINS. </b>";
        }
    }*/
}
