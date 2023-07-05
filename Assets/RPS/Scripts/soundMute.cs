using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundMute : MonoBehaviour
{
    AudioSource audioClip;
    public bool muteAudio;
    // Start is called before the first frame update
    void Start()
    {
        audioClip = GetComponent<AudioSource>();
        muteAudio = true;
    }

    public void muteSound()
    {
        audioClip.mute= muteAudio;
        muteAudio = !muteAudio; 
    }


}


