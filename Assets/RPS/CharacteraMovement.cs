using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacteraMovement : MonoBehaviour
{
    [Tooltip("Movement Values")]
    [SerializeField]
    float movementSpeed, rotationSpeed, gravityForce, jumpForce;

    [Header("Controls")]
    public string horizontalInput; 
    public string verticalInput;

    [Header("KeyCode")]
    public KeyCode Jump;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Up;
    public KeyCode Down;

    CharacterController cc;
    Animator anim;

    Vector3 movementDirection;
    Camera cam;

    public Transform target;

    // Gravity
    Vector3 playerVelocity;
    public bool isGroundedPlayer;
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
        isGroundedPlayer = cc.isGrounded;
        if(isGroundedPlayer && playerVelocity.y < 0)
        {
            if(anim.GetBool("isJumping"))
            {
                anim.SetBool("isJumping", false);
            }
            playerVelocity.y = 0; //Always keep the character to the ground.
        }
        //Get Iput
        float h = Input.GetAxis(horizontalInput);
        float v = Input.GetAxis(verticalInput);

        //For Keyboard
        //float h1 = Convert.ToInt64(Input.GetKey(KeyCode.A))*-1 + Convert.ToInt64(Input.GetKey(KeyCode.D));

        //Setting movement toward camera
        Vector3 camh = cam.transform.right;
        Vector3 camv = Vector3.Cross(camh, Vector3.up);
        if (h != 0 || v!=0)
        {
            movementDirection = camh * h + camv * v;
            movementDirection.Normalize();
            cc.Move(movementDirection * movementSpeed * Time.deltaTime);

            anim.SetBool("HasInput", true);
        }
        else
        {
            anim.SetBool("HasInput", false);
        }
        //Rotation
        Quaternion desiredDirection = Quaternion.LookRotation(movementDirection);

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredDirection, rotationSpeed);

        Vector3 animationVector = transform.InverseTransformDirection(cc.velocity);
        //Parse in value for movement animation
        anim.SetFloat("HorizontalSpeed", animationVector.x);
        anim.SetFloat("VerticalSpeed", animationVector.z);

        ProcessGravity();
    }

    public void ProcessGravity()
    {
        if (Input.GetKeyDown(Jump) && isGroundedPlayer)
        {
            //Jump anim goes here
            Debug.Log("Space is pressed");
            anim.SetBool("isJumping", true);
            //Adding jumpforce

            playerVelocity.y += Mathf.Sqrt(jumpForce * -3.0f * gravityForce);

        }
        
        playerVelocity.y += gravityForce * Time.deltaTime;
        cc.Move(playerVelocity * Time.deltaTime);
    }
}
