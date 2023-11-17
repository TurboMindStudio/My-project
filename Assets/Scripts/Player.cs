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

    private void Start()
    {
        rb=GetComponent<Rigidbody>();
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

            if(Input.GetMouseButtonDown(0)&&isGrounded)
            {
                Jump();
            }
        }
        else
        {
            isGrounded=false;
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce * Time.deltaTime, rb.velocity.z);
    }


}
