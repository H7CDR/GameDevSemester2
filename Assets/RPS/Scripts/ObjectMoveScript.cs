using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveScript : MonoBehaviour
{
    [SerializeField]
    float pushForce;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        PushOnSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, 0, -1f*pushForce*Time.deltaTime);
    }

    public void PushOnSpawn()
    {
    }
}
