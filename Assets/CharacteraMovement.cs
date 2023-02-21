using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteraMovement : MonoBehaviour
{
    [Tooltip("Movement Values")]
    [SerializeField]
    float movementSpeed, rotationSpeed;

    CharacterController cc;
    Animator anim;

    Vector3 movementDirection;
    Camera cam;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        anim.SetFloat("HorizontalSpeed", h);
        anim.SetFloat("VerticalSpeed", v);


        Vector3 camh = cam.transform.right;
        Vector3 camv = Vector3.Cross(camh, Vector3.up);


        movementDirection = camh * h + camv * v;
        movementDirection.Normalize();
        cc.Move(movementDirection * movementSpeed * Time.deltaTime);
    }
}
