using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class hitDetector : MonoBehaviour
{
    public RaycastHit hit;
    [SerializeField]
    Vector3 originPoint;
    [SerializeField]
    public float rayLength;
    [SerializeField]
    LayerMask _playerMask;
    [SerializeField]
    LayerMask _enemyMask;
    [SerializeField]
    public bool _hitable;
    [SerializeField]
    public float distanceToHitter;

    void Start()
    {

        
    }
    void OnEnable()
    {
        originPoint = gameObject.transform.position;
        _playerMask = LayerMask.GetMask("Player");
        _enemyMask = LayerMask.GetMask("Enemy");
        _hitable = false;
    }
    void Update()
    {
        distanceToHitter = hit.distance;
        if (Physics.Raycast(transform.position, Vector3.back, out hit, Mathf.Infinity, _playerMask))
        {
            _hitable = false;
            Debug.Log(hit.distance.ToString());
            Debug.DrawRay(transform.position, Vector3.back * hit.distance, Color.red);
            distanceToHitter = hit.distance;
            if (hit.distance <= rayLength) 
            {
                Debug.Log("Hit the beat Hitter");
                Debug.DrawRay(transform.position, Vector3.back * hit.distance, Color.yellow);
                Debug.Log(hit.collider.name);
                Debug.Log(hit.distance.ToString());
                _hitable = true;

            }
        }
       /* else if (Physics.Raycast(transform.position, Vector3.back, out hit, rayLength, _playerMask))
        {
            Debug.Log("Hit the beat Hitter");
            Debug.DrawRay(transform.position, Vector3.back * hit.distance, Color.yellow);
            Debug.Log(hit.collider.name);
            _hitable = true;
        }*/
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, rayLength, _playerMask))
        {
            Debug.Log("Hit the beat Hitter");
            Debug.DrawRay(transform.position, Vector3.forward * hit.distance, Color.yellow);
            Debug.Log(hit.collider.name);
            _hitable = true;
        }
        else if (Physics.Raycast(transform.position, Vector3.forward, out hit, Mathf.Infinity, _playerMask))
        {
            _hitable = false;
            Debug.DrawRay(transform.position, Vector3.back * hit.distance, Color.red);
        }
        else
        {
            _hitable = true;
        }
    }
}
