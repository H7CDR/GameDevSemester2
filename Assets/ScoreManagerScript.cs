using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

[System.Serializable]
public class ScoreManagerScript : MonoBehaviour
{
    [SerializeField]
    StageManager stageManager;
    [SerializeField]
    Canvas player1Canvas, player2Canvas;
    [SerializeField]
    TextMeshProUGUI p1ScoreTxt, p2ScoreTxt;
    [SerializeField]
    TextMeshProUGUI p1ComboTxt, p2ComboTxt;
    [SerializeField]
    TextMeshProUGUI timeElapsed;
    [SerializeField]
    AudioSource _song;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p1ScoreTxt.text = "SCORE: " + stageManager.player1Score;
        p1ComboTxt.text = "Combo: " + stageManager.p1ComboCount;
        timeElapsed.text = "timer: " + (_song.timeSamples/_song.clip.frequency)+"<br> time: " + _song.time;

        p2ScoreTxt.text = "SCORE:" + stageManager.player2Score;
        p2ComboTxt.text = "Combo: " + stageManager.p2ComboCount;

    }

}
