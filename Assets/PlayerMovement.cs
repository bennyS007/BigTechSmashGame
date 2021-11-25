using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform jumpPoint;

    public float speed;

    public float rotationY = -90f;
    public float rotationSpeed;
    public LayerMask groundMask;
    public bool isGrounded;


    Rigidbody rb;
    float jumpVelocity;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(jumpPoint.position, 0.5f, groundMask) ;

        if(isGrounded && rb.velocity.y < 0)
        {
            jumpVelocity = -2f;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpVelocity = Mathf.Sqrt(3f * -2f * -9.81f);
        }
        
        jumpVelocity += -9.81f * Time.deltaTime;
        rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, 0f);
        RotatePlayer();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y, 0f);
    }

    void RotatePlayer()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(rotationY), 0f);
        } 
    }
}