using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Player Properties")]
    CharacterController controller;

    private float speed;

    [SerializeField]
    private float moveSpeed = 12f;

    [SerializeField]
    private float sprintSpeed = 20f;

    [SerializeField]
    private float sprintSpeedIncrement;

    [SerializeField]
    private float cameraFOV;

    [SerializeField]
    private float maxCameraFOV, cameraZoomSpeed;

    [SerializeField]
    private float jumpHeight = 3f;

    [SerializeField]
    private float gravity = -9.81f;

    [SerializeField]
    private Vector3 spawnPosition;

    [SerializeField]
    private GameObject groundCheck;

    [SerializeField]
    private float groundDistance = .4f;

    [SerializeField]
    private float wallDistance = 1.2f;

    public LayerMask groundMask;
    public LayerMask wallMask;

    Vector3 velocity;

    bool isGrounded;
    bool isTouchingWall;
    bool isStandingOnWall;

    private void Start()
    {
        
        controller = GetComponent<CharacterController>();
        gameObject.transform.position = spawnPosition;
    }

    private void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);
        isStandingOnWall = Physics.CheckSphere(groundCheck.transform.position, groundDistance, wallMask);
        isTouchingWall = Physics.CheckSphere(transform.position, wallDistance, wallMask);

        if (isGrounded && velocity.y < 0 || isTouchingWall && velocity.y < 0 || isStandingOnWall && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isTouchingWall && Input.GetKey(KeyCode.W))
        {
            if (velocity.y <= 1 + (gameObject.GetComponentInChildren<MouseMovement>().xRotation * -0.08f) + (speed * 0.1f))
            {
                velocity.y += 3;
            }
                
        }

        if(Input.GetButtonDown("Jump") && isGrounded || Input.GetButtonDown("Jump") && isStandingOnWall || Input.GetButtonDown("Jump") && isTouchingWall)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && controller.velocity.x != 0)
        {
            if(speed < sprintSpeed)
            {
                speed += (sprintSpeedIncrement * Time.deltaTime);
            }
            if(Camera.main.fieldOfView < maxCameraFOV)
            {
                Camera.main.fieldOfView += cameraZoomSpeed * Time.deltaTime;
            }
        }
        else
        {
            if(speed > moveSpeed)
            {
                speed -= (sprintSpeedIncrement * Time.deltaTime);
            }
            else
            {
                speed = moveSpeed;
            }
            if(Camera.main.fieldOfView > cameraFOV)
            {
                Camera.main.fieldOfView -= cameraZoomSpeed * Time.deltaTime;
            }
        }
            
        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(transform.position.y < -100)
        {
            transform.position = spawnPosition;
        }
    }
}
