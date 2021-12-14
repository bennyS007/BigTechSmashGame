using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Transform jumpPoint;

    public float speed;
    public float jumpHeight;

    public LayerMask groundMask;
    public LayerMask solidGroundMask;

    public bool isSideways;
    public bool isGrounded;
    public bool isNonCrouchGround;
    public bool jumping;
    public int punches;
    public float punchTime;
    public bool kicking;

    public CapsuleCollider bodyColider;
    public Collider[] attackHitboxes;

    Rigidbody rb;
    float jumpVelocity;
    Vector3 startScale;
    Animator animator;
    private void Start()
    {
        startScale = transform.localScale;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(jumpPoint.position, 0.5f, groundMask);
        isNonCrouchGround = Physics.CheckSphere(jumpPoint.position, 0.5f, solidGroundMask);

        if ((isGrounded || isNonCrouchGround) && jumping)
        {
            jumping = false;
            animator.SetBool("Landed", true);
        }

        else if ((isGrounded || isNonCrouchGround) && rb.velocity.y < 0)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("Landed", false);
            animator.SetBool("IsFalling", false);
            jumpVelocity = -2f;
            bodyColider.enabled = true;
        }



        if (!(isGrounded || isNonCrouchGround) && rb.velocity.y < 0)
        {
            jumping = true;
            animator.SetBool("IsFalling", true);
        }


        else
        {
            kicking = false;
        }

        jumpVelocity += -9.81f * Time.deltaTime;
        rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, 0f);
        /*
            public Transform jumpPoint;

            public LayerMask groundMask;
            public LayerMask solidGroundMask;
            public bool isGrounded;
            public bool isNonCrouchGround;

            Rigidbody rb;
            float jumpVelocity;
            private void Start()
            {
                rb = GetComponent<Rigidbody>();
            }
            // Update is called once per frame
            void Update()
            {
                isGrounded = Physics.CheckSphere(jumpPoint.position, 0.5f, groundMask);
                isNonCrouchGround = Physics.CheckSphere(jumpPoint.position, 0.5f, solidGroundMask);

                if(isGrounded || isNonCrouchGround)
                {
                    jumpVelocity = -2f;
                }

                jumpVelocity += -9.81f * Time.deltaTime;
                rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, 0f);
            }
        */
    }
}

