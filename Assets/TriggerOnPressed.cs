using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnPressed : MonoBehaviour
{
    [SerializeField]
    private Collider _collider;
    // Start is called before the first frame update
    void Start()
    {
        _collider.GetComponent<Collider>();
    }

    private void OnEnable()
    {
        _collider = gameObject.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
