using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform jumpPoint;

    public float speed;
    public float jumpHeight;

    public LayerMask groundMask;
    public LayerMask solidGroundMask;
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

        if (Input.GetAxisRaw("Vertical") > 0 && (isGrounded || isNonCrouchGround))
        {
            
            animator.SetBool("IsJumping", true);
            jumpVelocity = Mathf.Sqrt(jumpHeight * -2f * -9.81f);
            bodyColider.enabled = false;
        }

        if(Input.GetAxisRaw("Vertical") < 0 && isGrounded)
        {
            animator.SetBool("IsCrouching", true);
            bodyColider.enabled = false;
            jumpVelocity = -Mathf.Sqrt(jumpHeight * -2f * -9.81f);
        }

        else if(Input.GetAxisRaw("Vertical") < 0 && isNonCrouchGround)
        {
            animator.SetBool("IsCrouching", true);
            bodyColider.height = 1f;
            bodyColider.center = new Vector3(-0.15f, 0.5f, 0);
        }

        if (Input.GetAxisRaw("Vertical") >= 0)
        {
            animator.SetBool("IsCrouching", false);
            bodyColider.height = 1.65f;
            bodyColider.center = new Vector3(-0.15f, 0.83f, 0);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Punch();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Kick();
        }
        else
        {
            kicking = false;
        }
        
        jumpVelocity += -9.81f * Time.deltaTime;
        rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, 0f);
        RotatePlayer();
    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal")!= 0)
        {
            rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y, 0f);
        }
        
    }

    void RotatePlayer()
    {
        transform.rotation = Quaternion.Euler(0,0,0);
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(-startScale.x, startScale.y, startScale.z);
            animator.SetBool("IsWalking", true);
            if (animator.GetBool("IsCrouching")) { 
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsCrouchWalking", true);
            }
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(startScale.x, startScale.y, startScale.z);
            animator.SetBool("IsWalking", true);
            if (animator.GetBool("IsCrouching"))
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsCrouchWalking", true);
            }
        }
        else{ 
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsCrouchWalking", false);
        }
    }

    void Kick()
    {
        kicking = true;
    }

    void Punch()
    {
        punches = animator.GetInteger("Punches") + 1;
        animator.SetInteger("Punches", punches);
    }

    public void punchEnd1()
    {
        if(animator.GetInteger("Punches") == 1)
        {
            animator.SetInteger("Punches", 0);
        }
    }
    public void punchEnd2()
    {
        if (animator.GetInteger("Punches") == 2)
        {
            animator.SetInteger("Punches", 0);
        }
    }
    public void punchEnd3()
    {
        animator.SetInteger("Punches", 0);
    }

    public void HitScanPunch1()
    {
        Collider[] cols = Physics.OverlapBox(attackHitboxes[0].bounds.center, attackHitboxes[0].bounds.extents, attackHitboxes[0].transform.rotation, LayerMask.GetMask("Hitboxes"));
        foreach (Collider c in cols)
        {
            if (c.transform == transform)
            {
                continue;
            }
            Debug.Log(c.name);
        }
    }

    public void HitScanPunch2()
    {
        Collider[] cols = Physics.OverlapBox(attackHitboxes[1].bounds.center, attackHitboxes[1].bounds.extents, attackHitboxes[1].transform.rotation, LayerMask.GetMask("Hitboxes"));
        foreach (Collider c in cols)
        {
            if (c.transform == transform)
            {
                continue;
            }
            Debug.Log(c.name);
        }
    }

    public void HitScanPunch3()
    {
        Collider[] cols = Physics.OverlapBox(attackHitboxes[2].bounds.center, attackHitboxes[2].bounds.extents, attackHitboxes[2].transform.rotation, LayerMask.GetMask("Hitboxes"));
        foreach (Collider c in cols)
        {
            if (c.transform == transform)
            {
                continue;
            }
            c.SendMessageUpwards("TakeDamage", 12);
        }
    }
}