using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManagerScript : MonoBehaviour
{
    public int player1Score = 0;
    public int comboCount;
    [SerializeField]
    Canvas player1Canvas;
    [SerializeField]
    TextMeshProUGUI p1ScoreTxt;
    [SerializeField]
    TextMeshProUGUI p1ComboTxt;

    [Header("Scoring Setting")]
    public int scPerfect;
    public int scOkay;
    public int scMissed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p1ScoreTxt.text = "SCORE: " + player1Score;
        p1ComboTxt.text = "Combo: " + comboCount;
    }
}
