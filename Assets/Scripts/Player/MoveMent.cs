using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    [Header("Move")]
    private float directX, directY;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    private Rigidbody2D rb;

    [Header("Jump")]
    [SerializeField] private BoxCollider2D groundCheck;
    [SerializeField] private LayerMask groundLayer;  
    private int cntJump;
    private bool isGround;
    public int CntJump
    {
        get { return cntJump; }
        set { cntJump = value; }
    }

    [Header("WallSlide")]
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private RaycastHit2D wallHit;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private float wallSlideSpeed;
    private bool isSlide;

    [Header("WallJump")]
    [SerializeField]private Vector2 wallJumpPower = new Vector2(6f, 12f);
    private bool isWallJump;
    private float wallJumpTime ;
    private float wallJumpCounter;
    private float wallJumpDirection;

    [Header("Animation")]
    private string currentState ;
    private AnimationControl animControl;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animControl = GetComponent<AnimationControl>();
        rb.gravityScale = 5f;
        speed = 10f;
        jumpPower = 18f;

        wallCheckDistance = 0.8f;
        wallSlideSpeed = 3.5f;
        wallJumpTime = 0.2f;
        //wallJumpDuration = 0.4f;

        currentState = "Idle";
    }

    void Update()
    {
        directX = Input.GetAxisRaw("Horizontal");
        directY = Input.GetAxisRaw("Vertical");
        isGround = Grounded();
        MovingAndJumping();
        WallSlide();
        WallJump();
        SetAnimator();
    }

    void MovingAndJumping()
    {
        if (directX > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (directX < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        rb.velocity = new Vector2(directX * speed, rb.velocity.y);
        if (isGround && rb.velocity.y < 0.1f)
            cntJump = 2;
        if (Input.GetButtonDown("Jump"))
        {
            if (cntJump == 2)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                cntJump -= 1;
                AudioManager.Instance.PlaySfx("Jump");
            }
            else if (cntJump == 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0.75f * jumpPower);
                cntJump -= 1;
                AudioManager.Instance.PlaySfx("Jump");

            }

        }
    }
    void WallSlide()
    {
        isSlide = Walled();
        if (isSlide && !isGround && directX != 0)
        {
            //rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
            rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
        }
        else
            isSlide = false;
    }

    void WallJump()
    {

        if (isSlide)
        {
            isWallJump = false;
            wallJumpDirection = -this.transform.localScale.x;
            wallJumpCounter = wallJumpTime;
            CancelInvoke(nameof(StopWallJump));
        }
        else
        {
            wallJumpCounter -= Time.deltaTime;
        }
        if(Input.GetButtonDown("Jump") && wallJumpCounter > 0f)
        {
            isWallJump = true;
            rb.velocity = new Vector2(wallJumpPower.x * wallJumpDirection, wallJumpPower.y);
            wallJumpCounter = 0f;

            AudioManager.Instance.PlaySfx("Jump");
            Invoke(nameof(StopWallJump), 0.5f);
        }
    }

    private void SetAnimator() 
    {
        if (animControl.IsPlayingAnimation("Die") || animControl.IsPlayingAnimation("TakeDame"))
            return;

        if (rb.velocity.y < 0f && !isSlide && !isGround)
        {
            animControl.ChangeState("Fall");
            return;
        }
        if (isWallJump)
        {
            animControl.ChangeState("Jump");
            return ;
        }

        if (isGround)
        {
            if (Mathf.Abs(rb.velocity.x) > 0.1f)
                animControl.ChangeState("Run");
            else
                animControl.ChangeState("Idle");
        }
        else
        {
            if (!isSlide)
            {
                if (cntJump == 1)
                    animControl.ChangeState("Jump");
                else if (cntJump == 0)
                    animControl.ChangeState("DoubleJump");
            }
            else
            {
                if (isWallJump)
                    animControl.ChangeState("Jump");
                else
                    animControl.ChangeState("Slide");
            }
        }
    }


    bool Walled()
    {
        if (directX > 0)
        {
            wallHit = Physics2D.Raycast(this.transform.position, Vector2.right, wallCheckDistance, wallLayer);
        }
        else if (directX < 0)
        {
            wallHit = Physics2D.Raycast(this.transform.position, Vector2.left, wallCheckDistance, wallLayer);
        }
        return wallHit;
    }
    bool Grounded()
    {
        return Physics2D.OverlapBox(groundCheck.bounds.center, groundCheck.bounds.size, 0f, groundLayer);
    }

    private void StopWallJump()
    {
        this.isWallJump = false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(this.transform.position, new Vector3(transform.position.x + wallCheckDistance,
            transform.position.y, transform.position.z));
    }
}
    