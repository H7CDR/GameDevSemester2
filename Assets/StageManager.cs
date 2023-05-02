using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public Health player1Health;
    public ScoreManagerScript scoreManagerScript;
    public AudioSource _sound;

    public int player1Score =0;
    public int player2Score =0;
    public int p1ComboCount;
    public int p2ComboCount;
    [Header("UI")]
    public CanvasGroup p1GameOverCanvas;
    public CanvasGroup p1PausedScreen;

    [Header("Scoring Setting")]
    public int scPerfect;
    public int scOkay;
    public int scMissed;

    #region Singleton
    public static StageManager instance;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    #endregion


    private void Start()
    {

    }

    
    private void Update()
    {
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

    public void gamePaused()
    {
        p1PausedScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
        _sound.GetComponent<AudioSource>().Pause();
    }
}
