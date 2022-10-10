using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerController : MonoBehaviour
{
    
    /// <summary>
    /// Animation controller for the character
    /// 
    ///  **BUGS**
    /// -Walk backwards doesn't decrease
    /// -The bot has a weird slant when moving. Unsure which movement angle causes this
    /// </summary>
    
    [Header("References",order = 1)]
    public CharacterController controller;
    public Animator animator;
    public Transform cam;
    
    [Header("Character Settings",order = 2)]
    //old
    /*public float velocityZ = 0.0f;
    public float velocityX = 0.0f;*/
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    
    //new
    public float turnSmooth = 0.1f;
    public float turnSmoothVelocity;
    public float speed = 6f;
    public Vector3 velocity;
    public float maxWalkVelocity = 0.5f;
    public float maxRunVelocity = 1f;
    public bool runPressed;
    
    [Header("Gravity Settings",order = 3)]
    public float gravity = -9.71f;
    [Range(0, 100)] public float Gravity_Multiplier;
    [Range(0, 20)] public float JumpForce ;
    public float gizmo;
    public bool groundCheck;

    void Start()
    {
        //Grab controller components
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
        //Set Cursor to not be visible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        NewMovement();
       
    }

    void OldMovement()
    {
        /*bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool backPressed = Input.GetKey("s");
        
        // if player presses forward, increase velocity in z direction
       if (forwardPressed && velocityZ < 0.5f)
       {
           velocityZ += Time.deltaTime * acceleration;
       }

       // increase velocity in back direction
       if (backPressed && velocityZ > -0.5f)
       {
           velocityZ -= Time.deltaTime * acceleration;
       }

       //increase velocity in left direction
       if (leftPressed && velocityX > -0.5f)
       {
           velocityX -= Time.deltaTime * acceleration;
       }

       // increase velocity in right direction 
       if (rightPressed && velocityX < 0.5f)
       {
           velocityX += Time.deltaTime * acceleration;
       }

       // decrease velocityZ forwards
       if (!forwardPressed && velocityZ > 0.0f)
       {
           velocityZ -= Time.deltaTime * deceleration;
       }
       
       // decrease velocityz backward
       if (!backPressed && velocityZ < 0.0f)
       {
           velocityZ += Time.deltaTime * deceleration;
       }

       //reset velocityZ
       if (!forwardPressed && !backPressed && velocityZ != 0.0f && (velocityZ > -0.5 && velocityZ  < 0.5f))
       {
           velocityZ = 0.0f;
       }

       // increase velocityX if left is not pressed and velocity < 0
       if (!leftPressed && velocityX < 0.0f)
       {
           velocityX += Time.deltaTime * deceleration;
       }

       // decrease velocityX if right is not pressed and velocityX > 0
       if (!rightPressed && velocityX > 0.0f)
       {
           velocityX -= Time.deltaTime * deceleration;
       }
       
       //reset velocityX
       if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
       {
           velocityX = 0.0f;
       }
        
        //sets animation floats to the floats in the script
        animator.SetFloat("VelocityZ", velocityZ);
        animator.SetFloat("VelocityX", velocityX);*/
    }

    void NewMovement()
    {
        float velocityX = Input.GetAxisRaw("Horizontal");
        float velocityZ = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(velocityX, 0f, velocityZ).normalized;

        
        //float currentMaxVelocity = runPressed ? maxRunVelocity : maxWalkVelocity;
        
        
         //create a target angle that moves the player in the direction of the camera given the input from the character controller
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                turnSmooth);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            runPressed = true;
            animator.SetBool("isRunning",true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            runPressed = false;
            animator.SetBool("isRunning",false);
        }

        animator.SetFloat("VelocityZ", velocityZ);
        animator.SetFloat("VelocityX", velocityX);
    }

    void Attack()
    {
        /*if (Input.GetButton(MouseButton.LeftMouse))
        {
            
        }*/
    }
}


