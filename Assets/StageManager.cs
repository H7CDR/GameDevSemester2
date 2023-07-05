using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public Health player1Health;
    public ScoreManagerScript scoreManagerScript;
    public AudioSource _sound;

    [SerializeField]
    GameController _p1ControllerScript, _p2ControllerScript;

    public int player1Score =0;
    public int player2Score =0;
    public int p1ComboCount;
    public int p2ComboCount;
    
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


    private void Start()
    {
       _player1GameOver = false;
       _player2GameOver = false;
        player1Win = false;
        player2Win= false;
    }

    
    private void Update()
    {
        if (_player1GameOver && _player2GameOver) 
        {
            Time.timeScale = 0f;
            allGameOver();
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
        //p1GameOverCanvas.gameObject.SetActive(true);
        _p1ControllerScript.gameObject.SetActive(false);
        //SaveP1Score();
        _player1GameOver = true;
        _p1NodeKiller.gameObject.SetActive(false);
    }
    public void Player2GameOver()
    {
        //p2GameOverCanvas.gameObject.SetActive(true);
        _p2ControllerScript.gameObject.SetActive(false);
        //SaveP2Score();
        _player2GameOver = true;
        _p2NodeKiller.gameObject.SetActive(false);
    }
    public void allGameOver()
    {
        p1GameOverCanvas.gameObject.SetActive(false);
        p2GameOverCanvas.gameObject.SetActive(false);
        _p1ControllerScript.gameObject.SetActive(true);
        _p2ControllerScript.gameObject.SetActive(true);
        allGameOverScreen.gameObject.SetActive(true);
        compareScore();
        _sound.Stop();
        declareWinnerTxt.text = winningText + "P1: " + player1Score + ".     " + "P2: " + player2Score +"." ;

    }

    public void gamePaused()
    {
        p1PausedScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
        _sound.GetComponent<AudioSource>().Pause();
    }

    public void SaveP1Score()
    {
        GameMaster.instance.saveData.player1Scores.Add(player1Score);
        GameMaster.instance.saveData.player1Scores.Sort(SortFunc);
        SaveSystemScript.instance.SaveGame(GameMaster.instance.saveData);
        Debug.Log("Data Save");
    }

    public void SaveP2Score()
    {
        GameMaster.instance.saveData.player2Scores.Add(player2Score);
        GameMaster.instance.saveData.player2Scores.Sort(SortFunc);
        SaveSystemScript.instance.SaveGame(GameMaster.instance.saveData);
    }

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

    public void compareScore()
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
    }
}
