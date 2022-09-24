using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    /// <summary>
    /// Animation controller for the character
    /// 
    ///  **BUGS**
    /// Walk backwards doesn't decrease
    /// The bot has a weird slant when moving. Unsure which movement angle causes this 
    /// </summary>
    
    
    public CharacterController controller;
    public Animator animator;
    public float velocityZ = 0.0f;
    public float velocityX = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
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
        if (!forwardPressed && velocityZ < 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
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
        animator.SetFloat("VelocityX", velocityX);
    }
}


