using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColliderScript : hitDetector
{

    [SerializeField]
    enum TypeOfCollision { Rock, Paper, Scissors };
    [SerializeField]
    TypeOfCollision currentType;
    [SerializeField]
    AudioSource wrongSound;
    

    public int comboCount;
    public int comboMultiplyer;

    [Header("Referecing other Script")]
    [SerializeField]
    ScoreManagerScript SMS;

    // Start is called before the first frame update
    void Start()
    {
        comboMultiplyer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (comboCount >= 10 && comboCount <=25)
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
        if(_hitable == true)
        {
            if (other.CompareTag(currentType.ToString()) && ((hit.distance > 0.5f && hit.distance <5f)|| (hit2.distance > 0.5f && hit2.distance < 5f)))
            {
                Debug.Log(currentType.ToString());
                Destroy(other.gameObject);
                Debug.Log("OKAY!");
                gameObject.GetComponent<Collider>().enabled = false;
                SMS.player1Score += (comboMultiplyer * SMS.scOkay);
                SMS.comboCount += 1;
            }
            else if (other.CompareTag(currentType.ToString()) && (hit.distance < 0.5f && hit2.distance <0.5))
            {
                Debug.Log(currentType.ToString());
                Destroy(other.gameObject);
                Debug.Log("PERFECT");
                gameObject.GetComponent<Collider>().enabled = false;
                SMS.player1Score += (comboMultiplyer *SMS.scPerfect);
                SMS.comboCount += 1;
            }
            else if (other.CompareTag(currentType.ToString()) &&(hit.distance==0 && hit2.distance == 0))
            {
                Debug.Log(currentType.ToString());
                Destroy(other.gameObject);
                Debug.Log("AMAZING");
                gameObject.GetComponent<Collider>().enabled = false;
            }
            else if (other.CompareTag(currentType.ToString())&& (hit.distance>5f|| hit2.distance > 5f))
            {
                Debug.Log(currentType.ToString());
                Destroy(other.gameObject);
                Debug.Log("MISSED");
                gameObject.GetComponent<Collider>().enabled = false;
                SMS.player1Score += SMS.scMissed;
                SMS.comboCount = 0;
            }
            else if (!other.CompareTag(currentType.ToString()))
            {
                Debug.Log("WrongType");
                gameObject.GetComponent<Collider>().enabled = false;
                Destroy(other.gameObject);
                SMS.player1Score += SMS.scMissed;
                SMS.comboCount = 0;
                wrongSound.Play();
            }
        }
       
    }
}
