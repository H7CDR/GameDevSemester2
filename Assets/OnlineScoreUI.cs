using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using System;

public class OnlineScoreUI : MonoBehaviour
{
    private PhotonView view;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI comboUI;
    public int playerScore;
    public int playerCombo;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponentInParent<PhotonView>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreAndCombo()
    {
        string score = "SCORE: ";
        string combo = "COMBO: ";
        scoreUI.text = score += playerScore.ToString();
        comboUI.text = combo += playerCombo.ToString();

    }

    
}
