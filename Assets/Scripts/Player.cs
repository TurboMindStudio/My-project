using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody rb;
    public bool isGrounded;
    public Transform groundPos;
    public LayerMask layerName;
    public float maxRange;
    RaycastHit hit;
    Ray ray;

    // animation
    private Animator animator;


    private void Start()
    {
        rb=GetComponent<Rigidbody>();
        animator=GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        raycastDetection();
    }

    void raycastDetection()
    {
        ray = new Ray(groundPos.position, -Vector3.up);
        Debug.DrawRay(groundPos.position, -Vector3.up, Color.yellow);
        if (Physics.Raycast(ray, out hit,maxRange,layerName))
        {
           
            isGrounded=true;
            Debug.Log("ground");
            animator.SetBool("jump", false);

            if (Input.GetMouseButtonDown(0)&&isGrounded)
            {
                Jump();
            }
        }
        else
        {
            isGrounded=false;
            animator.SetBool("jump", true);
        }

       
    }

    void Jump()
    {
       
        rb.velocity = new Vector3(rb.velocity.x, jumpForce * Time.deltaTime, rb.velocity.z);
    }


}
