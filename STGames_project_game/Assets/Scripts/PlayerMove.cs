using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveVector, dashVector;
    public float speed = 2f;
    public Animator anim;
    public SpriteRenderer sr;
    public bool faceRight = true;
    public float jumpForce = 350f;
    public bool onGround;
    public Transform GroundCheck;
    public float GroundCheckRadius = 0.5f;
    public LayerMask Ground;
    public bool spacePushed;
    public float VerticalSpeed;
    public bool xPushed;
    public bool zPushed;
    public int hitPower = 50;
    public int hp = 100;
    public int power = 100;
    public int airDashNum = 1;
    public int DashQ = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Walk();
        Reflect();
        Jump();
        CheckingGround();
        CheckingVerticalSpeed();
        spaceCheck();
        xCheck();
        if (Input.GetKeyDown(KeyCode.LeftShift) && airDashNum > 0)
    {
        if (faceRight)
        {
            StartCoroutine(Dash(Vector2.right));
            airDashNum--;
        }
        else
        {
            StartCoroutine(Dash(Vector2.left));
            airDashNum--;
        }
    }
    }
    private IEnumerator Dash(Vector2 direction)
    {
        rb.gravityScale = 0f;
        anim.Play("dash");
        float dashTime = 0.55f;
        float dashSpeed = 10f;
        float elapsed = 0f;

        while (elapsed < dashTime)
        {
            rb.velocity = direction * dashSpeed;
            elapsed += Time.deltaTime;
            yield return null;
        }

        rb.velocity = Vector2.zero;
        rb.gravityScale = 1f;
    }

    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal"); 
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            //rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            rb.AddForce(Vector2.up * jumpForce);
            anim.StopPlayback();
        }
    }
    
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground);
        airDashNum = DashQ;
        anim.SetBool("onGround", onGround);
    }

    void CheckingVerticalSpeed()
    {
        VerticalSpeed = rb.velocity.y;
        anim.SetFloat("verticalSpeed", VerticalSpeed);

    }
    void spaceCheck()
    {
        spacePushed = Input.GetKeyDown(KeyCode.Space);
        anim.SetBool("spacePushed", spacePushed);
    }

    void xCheck()
    {
        xPushed = Input.GetKeyDown(KeyCode.X);
        anim.SetBool("isDeadTest", xPushed);
    }
} 
