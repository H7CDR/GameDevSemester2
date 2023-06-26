using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnlineColliderScript : hitDetector
{
    [SerializeField]
    enum TypeOfCollision { Rock, Paper, Scissors , Clearing};
    [SerializeField]
    TypeOfCollision currentType;
    [SerializeField]
    AudioSource wrongSound;
    [SerializeField]
    OnlineHealthUI onlineHealthUIScript;


    public int comboCount;
    public int comboMultiplyer;

    [Header("Referecing other Script")]
    [SerializeField]
    OnlineStageManager OnlineStageManager;

    [SerializeField]
    OnlineScoreUI onlineScoreUI;

    public GameData saveData;

    [SerializeField]
    ParticleSystem p1Perfect, p1Okay, p1Missed, p1Pass;

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
        if (onlineScoreUI.playerCombo >= 10 && onlineScoreUI.playerCombo <= 25)
        {
            comboMultiplyer = 2;
        }
        else if (onlineScoreUI.playerCombo > 25 && onlineScoreUI.playerCombo <= 50)
        {
            comboMultiplyer = 3;
        }
        else if (onlineScoreUI.playerCombo > 50)
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
            if (currentType == TypeOfCollision.Clearing && !other.CompareTag(currentType.ToString()))
            {
                view.RPC("ClearingObject", RpcTarget.All);
                PhotonNetwork.Destroy(other.gameObject);
                view.RPC("DeadCheck", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber);
            }
            else if (other.CompareTag(currentType.ToString()) && ((hit.distance > 0.5f && hit.distance < 5f) || (hit2.distance > 0.5f && hit2.distance < 5f)))
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
                view.RPC("DeadCheck", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber);
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
                view.RPC("AddPassScore", RpcTarget.All);
                view.RPC("DeadCheck", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber);
            }
            else if (!other.CompareTag(currentType.ToString()))
            {
                Debug.Log("WrongType");
                PhotonNetwork.Destroy(other.gameObject);
                view.RPC("AddWrongScore", RpcTarget.All);
                view.RPC("DeadCheck", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber);
            }
            
        }

    }


    [PunRPC]
    void AddPerfectScore()
    {
        Debug.Log("PerfectFunctionFound");
        p1Perfect.Play();
        gameObject.GetComponent<Collider>().enabled = false;
        //OnlineStageManager.player1Score[PhotonNetwork.LocalPlayer.ActorNumber -1] += (comboMultiplyer * OnlineStageManager.scPerfect);
        //OnlineStageManager.p1ComboCount[PhotonNetwork.LocalPlayer.ActorNumber - 1] += 1;
        onlineScoreUI.playerScore += (comboMultiplyer * OnlineStageManager.scPerfect);
        onlineScoreUI.playerCombo++;
        onlineScoreUI.UpdateScoreAndCombo();
    }
    [PunRPC]
    void AddOkayScore()
    {
        Debug.Log("OkayFunctionFound");
        p1Okay.Play();
        gameObject.GetComponent<Collider>().enabled = false;
        //OnlineStageManager.player1Score[PhotonNetwork.LocalPlayer.ActorNumber - 1] += (comboMultiplyer * OnlineStageManager.scOkay);
        //OnlineStageManager.p1ComboCount[PhotonNetwork.LocalPlayer.ActorNumber - 1] += 1;
        onlineScoreUI.playerScore += (comboMultiplyer * OnlineStageManager.scOkay);
        onlineScoreUI.playerCombo++;
        onlineScoreUI.UpdateScoreAndCombo();
    }
    [PunRPC]
    void AddAmazingScore()
    {
        Debug.Log("AmazingFunctionFound");
        p1Perfect.Play();
        gameObject.GetComponent<Collider>().enabled = false;
        //OnlineStageManager.player1Score[PhotonNetwork.LocalPlayer.ActorNumber - 1] += (comboMultiplyer * OnlineStageManager.scOkay);
        //OnlineStageManager.p1ComboCount[PhotonNetwork.LocalPlayer.ActorNumber - 1] += 5;
        onlineScoreUI.UpdateScoreAndCombo();
        onlineScoreUI.playerScore += OnlineStageManager.scPerfect * 50;
        onlineScoreUI.playerCombo++;
    }
    [PunRPC]
    void AddPassScore()
    {
        Debug.Log("PassFunctionFound");
        p1Missed.Play();
        gameObject.GetComponent<Collider>().enabled = false;
        //OnlineStageManager.player1Score[PhotonNetwork.LocalPlayer.ActorNumber - 1] += (comboMultiplyer * OnlineStageManager.scMissed);
        //OnlineStageManager.p1ComboCount[PhotonNetwork.LocalPlayer.ActorNumber - 1] = 0;
        onlineScoreUI.playerScore += (comboMultiplyer * OnlineStageManager.scPass);
        onlineScoreUI.playerCombo ++;
        onlineScoreUI.UpdateScoreAndCombo();
        onlineHealthUIScript.TakeDamge(2);

    }

    [PunRPC]
    void AddWrongScore()
    {
        Debug.Log("WrongFunctionFound");
        p1Missed.Play();
        gameObject.GetComponent<Collider>().enabled = false;
        //OnlineStageManager.player1Score[PhotonNetwork.LocalPlayer.ActorNumber - 1] += (comboMultiplyer * OnlineStageManager.scMissed);
        //OnlineStageManager.p1ComboCount[PhotonNetwork.LocalPlayer.ActorNumber - 1] = 0;
        onlineScoreUI.playerScore +=OnlineStageManager.scMissed;
        onlineScoreUI.playerCombo = 0;
        onlineScoreUI.UpdateScoreAndCombo();
        onlineHealthUIScript.TakeDamge(1);
    }

    [PunRPC]
    void ClearingObject()
    {
        Debug.Log("MissedFunctionFound");
        p1Missed.Play();
        //OnlineStageManager.player1Score[PhotonNetwork.LocalPlayer.ActorNumber - 1] += (comboMultiplyer * OnlineStageManager.scMissed);
        //OnlineStageManager.p1ComboCount[PhotonNetwork.LocalPlayer.ActorNumber - 1] = 0;
        onlineScoreUI.UpdateScoreAndCombo();
        onlineScoreUI.playerScore += OnlineStageManager.scMissed;
        onlineScoreUI.playerCombo = 0;
        onlineHealthUIScript.TakeDamge(2);
    }

    [PunRPC]
    void DestroyGameObject(GameObject other)
    {
        Destroy(other);
    }

    [PunRPC]
    void DeadCheck(int playerNum)
    {
        if (onlineHealthUIScript.isDead)
        {
            OnlineStageManager.playerDeath[playerNum-1] = true; 
        }
    }
}
