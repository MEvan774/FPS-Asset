using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public CharacterController controller;

    //movement
    public float speed = 12f;
    private float resetSpeed;

    public float sprintSpeed = 20f;
    bool sprint = false;

    //SprintEvent
    public UnityEvent isSprintingEvent;
    public UnityEvent isNotSprintingEvent;

    //Crouch
    public float crouchMoveSpeed = 4f;
    public float crouchSpeed = 0.1f;
    float defaultHeight = 2.0f;
    float crouchHeight = 0.5f;
    bool crouch = false;
    float currentHeight = 2.0f;


    //Gravity
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayer;

    Vector3 velocity;
    bool isGrounded;



    //crouch
    CharacterController characterController;
    //CapsuleCollider capCollider;





    private void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        //capCollider = gameObject.GetComponent<CapsuleCollider>();
        resetSpeed = speed;

    }
    void Update()
    {
        BaseMovement();
        Sprint();
        Crouch();
    }



    //Functions
    void BaseMovement()
    {
        bool isSprinting = sprint && isGrounded;

        //Groundcheck
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //movement

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }


    void Sprint()
    {
        //Sprint
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && isGrounded && crouch == false)
        {
            isSprintingEvent.Invoke();
            sprint = true;
            speed = sprintSpeed;
        }
        else
        {
            isNotSprintingEvent.Invoke();
            sprint = false;
            speed = resetSpeed;
        }
    }

    void Crouch()
    {

        characterController.height = currentHeight;

        //Crouch
        if (Input.GetKey(KeyCode.Z) && isGrounded && sprint == false)
        {
            //sprint = false;
            crouch = true;

            //characterController.height = 0.5f;
            speed = crouchMoveSpeed;
        }
        else if (sprint == false)
        {
            crouch = false;
            //characterController.height = 2.0f;
            speed = resetSpeed;
        }

        if(crouch == true && currentHeight > crouchHeight)
        {
            Debug.Log("crouchTRUE");
            currentHeight -= crouchSpeed * Time.deltaTime;
        }
        else if(crouch == false && currentHeight < defaultHeight)
        {
            Debug.Log("crouchFALSE");
            currentHeight += crouchSpeed * Time.deltaTime;
        }
    }


}



