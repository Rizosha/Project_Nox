using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonMovemnetScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public bool playerGrounded;
    private Vector3 playerVelocity;
    public float jumpHeight = 5;
    public float gravityValue = -11f;

    public float speed = 4f;

    public float turnSmoothTime = 0.2f;
    private float turnSmoothVelocity;
    
    public Animator animator;
    public float waitTime = 0.15f;

    private void Awake() { animator = GetComponent<Animator>(); }
    void Update() {
        if (playerGrounded == false) {playerGrounded = controller.isGrounded;}
        if (playerGrounded && playerVelocity.y < 0) { playerVelocity.y = 0f;}
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            
            if (waitTime <= 0) { animator.SetBool("Running", true); }
            else { waitTime -= Time.deltaTime; }
        }
        else {
            animator.SetBool("Running", false);
            if (Input.GetMouseButtonDown(0)) { animator.Play("Interact", 0, 0.0f); }
        }
        
        //Jumping
        if (Input.GetButtonDown("Jump") && playerGrounded) { Jump(); }
        
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    
    void Jump() {
        //Vector3 jumpDir = Quaternion.Euler(0f, jumpSpeed, 0f) * Vector3.up;
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        playerGrounded = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PortalTop")) 
        { transform.position += new Vector3(0, 0, 6); }
        else if (other.CompareTag("PortalBottom")) 
        { transform.position += new Vector3(0, 0, -6); }
        else if (other.CompareTag("PortalRight")) 
        { transform.position += new Vector3(10, 0, 0); }
        else if (other.CompareTag("PortalLeft")) 
        { transform.position += new Vector3(-10, 0, 0); }
        else if (other.CompareTag("PortalExit")) {
            ProgressSaver.instance.SaveProgress(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else if (other.CompareTag("EnemyDetecter")) 
        { transform.position = new Vector3(0, 1.1f, 0); }
    }
}
