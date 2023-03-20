using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveScript : MonoBehaviour
{
    [SerializeField]
    float pushForce;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        this.rb = GetComponent<Rigidbody>();
        PushOnSpawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PushOnSpawn()
    {
        rb.AddForce(Vector3.back * pushForce *100);
    }
}
