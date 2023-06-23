using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;

public class OnlineScoreUI : MonoBehaviour
{
    private PhotonView view;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI comboUI;
    public OnlineStageManager OSM;
    

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponentInParent<PhotonView>();
        OSM = GameObject.Find("LevelManager").GetComponent<OnlineStageManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreAndCombo()
    {
        string score = "SCORE: ";
        string combo = "COMBO: ";
        scoreUI.text = score += OSM.player1Score;
        comboUI.text = combo += OSM.p1ComboCount;

    }
}
