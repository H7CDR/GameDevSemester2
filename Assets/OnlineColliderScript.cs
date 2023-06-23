using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnlineColliderScript : hitDetector
{
    [SerializeField]
    enum TypeOfCollision { Rock, Paper, Scissors };
    [SerializeField]
    TypeOfCollision currentType;
    [SerializeField]
    AudioSource wrongSound;
    [SerializeField]
    HealthUI healthUIScript;


    public int comboCount;
    public int comboMultiplyer;

    [Header("Referecing other Script")]
    [SerializeField]
    ScoreManagerScript SMS;

    [SerializeField]
    OnlineStageManager OnlineStageManager;

    [SerializeField]
    OnlineScoreUI onlineScoreUI;

    public GameData saveData;

    [SerializeField]
    ParticleSystem p1Perfect, p1Okay, p1Missed;

    private PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        comboMultiplyer = 1;
        OnlineStageManager = GameObject.Find("LevelManager").GetComponent<OnlineStageManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (comboCount >= 10 && comboCount <= 25)
        {
            comboMultiplyer = 2;
        }
        else if (comboCount > 25 && comboCount <= 50)
        {
            comboMultiplyer = 3;
        }
        else if (comboCount > 50)
        {
            comboMultiplyer = 5;
        }
        else
        {
            comboMultiplyer = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!view.IsMine) return;
        if (!_hitable) return;
        if (view.IsMine)
        {
            if (other.CompareTag(currentType.ToString()) && ((hit.distance > 0.5f && hit.distance < 5f) || (hit2.distance > 0.5f && hit2.distance < 5f)))
            {
                PhotonNetwork.Destroy(other.gameObject);
                Debug.Log("OKAY!");
                view.RPC("AddOkayScore", RpcTarget.All);
            }
            else if (other.CompareTag(currentType.ToString()) && (hit.distance < 0.5f && hit2.distance < 0.5))
            {
                PhotonNetwork.Destroy(other.gameObject);
                Debug.Log("PERFECT");
                view.RPC("AddPerfectScore", RpcTarget.All);
            }
            else if (other.CompareTag(currentType.ToString()) && (hit.distance == 0 && hit2.distance == 0))
            {
                PhotonNetwork.Destroy(other.gameObject);
                Debug.Log("AMAZING");
                view.RPC("AddAmazingScore", RpcTarget.All);
            }
            else if (other.CompareTag(currentType.ToString()) && (hit.distance > 5f || hit2.distance > 5f))
            {
                PhotonNetwork.Destroy(other.gameObject);
                Debug.Log("MISSED");
                view.RPC("AddMissedScore", RpcTarget.All);
            }
            else if (!other.CompareTag(currentType.ToString()))
            {
                Debug.Log("WrongType");
                PhotonNetwork.Destroy(other.gameObject);
                view.RPC("AddMissedScore", RpcTarget.All);
            }
        }

    }


    [PunRPC]
    void AddPerfectScore()
    {
        Debug.Log("PerfectFunctionFound");
        p1Perfect.Play();
        gameObject.GetComponent<Collider>().enabled = false;
        OnlineStageManager.player1Score += (comboMultiplyer * OnlineStageManager.scPerfect);
        OnlineStageManager.p1ComboCount += 1;
        onlineScoreUI.UpdateScoreAndCombo();
    }
    [PunRPC]
    void AddOkayScore()
    {
        Debug.Log("OkayFunctionFound");
        p1Okay.Play();
        gameObject.GetComponent<Collider>().enabled = false;
        OnlineStageManager.player1Score += (comboMultiplyer * OnlineStageManager.scOkay);
        OnlineStageManager.p1ComboCount += 1;
        onlineScoreUI.UpdateScoreAndCombo();
    }
    [PunRPC]
    void AddAmazingScore()
    {
        Debug.Log("AmazingFunctionFound");
        p1Perfect.Play();
        gameObject.GetComponent<Collider>().enabled = false;
        OnlineStageManager.player1Score += (comboMultiplyer * OnlineStageManager.scOkay);
        OnlineStageManager.p1ComboCount += 5;
        onlineScoreUI.UpdateScoreAndCombo();
    }
    [PunRPC]
    void AddMissedScore()
    {
        Debug.Log("MissedFunctionFound");
        p1Missed.Play();
        gameObject.GetComponent<Collider>().enabled = false;
        OnlineStageManager.player1Score += (comboMultiplyer * OnlineStageManager.scMissed);
        OnlineStageManager.p1ComboCount = 0;
        onlineScoreUI.UpdateScoreAndCombo();
    }

    [PunRPC]
    void DestroyGameObject(GameObject other)
    {
        Destroy(other);
    }
}
