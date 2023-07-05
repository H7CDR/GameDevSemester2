using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine.Events;
using Photon.Pun;

public class OnlineTimer : MonoBehaviour, IOnEventCallback  
{
    public float startTIme;
    public float currentTime;

    public string displayTime;
    public bool isTiming = false;

    //Define the photon event
    private const byte TIMER_TICK = 1;

    public UnityEvent TimesUp;

    #region Photon Raise Event Code
    //Enable and disable the ability to listen to events
    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
        
    }
    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void OnEvent (EventData data)
    {

    }

    #endregion

    void Update()
    {
        if(isTiming)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <=0 )
            {
                displayTime = "0";
                isTiming = false;
                TimesUp.Invoke();
            }
            else
            {
                displayTime = "0";
            }
        }
    }

}
