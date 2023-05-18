using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class hitDetector : MonoBehaviour
{
    public static RaycastHit hit;
    public static RaycastHit hit2;
    [SerializeField]
    Vector3 originPoint;
    [SerializeField]
    public float rayLength;
    [SerializeField]
    LayerMask _playerMask;
    [SerializeField]
    LayerMask _enemyMask;
    [SerializeField]
    public static bool _hitable;
    [SerializeField]
    float dist, dist2;

    void Start()
    {
        originPoint = gameObject.transform.position;
        _playerMask = LayerMask.GetMask("Player");
        _enemyMask = LayerMask.GetMask("Enemy");
        _hitable = false;

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
        dist = hit.distance;
        dist2 = hit2.distance;
       if (Physics.Raycast(originPoint, transform.TransformDirection(Vector3.forward), out hit, rayLength, _enemyMask))
       {
            Debug.Log(hit.collider.gameObject.name.ToString());
            Debug.DrawLine(originPoint, hit.point, Color.red);
            if(hit.distance<7f)
            {
                _hitable = true;
            }
            if(hit.distance>7f)
            {
                _hitable = false;
            }
       }
       if( Physics.Raycast(originPoint, transform.TransformDirection(Vector3.back), out hit2, rayLength, _enemyMask))
       {
            Debug.Log(hit2.collider.gameObject.name.ToString());
            Debug.DrawLine(originPoint, hit2.point, Color.yellow);
            if (hit2.distance < 7f)
            {
                _hitable = true;
            }
            if (hit2.distance > 7f)
            {
                _hitable = false;
            }
       }
    }
}
