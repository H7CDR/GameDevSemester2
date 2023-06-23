using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OnlineDestroyObject : MonoBehaviour
{
    [SerializeField]
    HealthUI healthUIScript;
    private PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponentInParent<PhotonView>();  
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        PhotonNetwork.Destroy(other.gameObject);
        healthUIScript.TakeDamge(2);
    }

    [PunRPC]
    public void DestroyObject(Collider other)
    {
        healthUIScript.TakeDamge(2);
        Destroy(other.gameObject);
    }

}
