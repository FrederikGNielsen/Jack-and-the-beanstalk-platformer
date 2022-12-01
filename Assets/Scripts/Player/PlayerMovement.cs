using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Walk")]
    public float Horizontal;
    private bool facingRight = true;
    float Speed;

    [Header("Jump")]
    public float jumpHeight;
    public float mayJump;
    public bool isGrounded;
    public Transform groundcheck;
    public float radius;
    public LayerMask groundLayer;

    public float acceleration;

    public Rigidbody2D rb;

    public Animator animator;

    //Animations
    public bool isCursorCenter;
    public bool isWalking;

    void Update()
    {
        //Left and Right input
        Horizontal = Input.GetAxisRaw("Horizontal");
        if(this.GetComponent<playerAttack>().isAttacking == false)
        {
            if (Horizontal > 0.25) //If walking right do this
            {
                animator.Play("PlayerWalk");

            }
            if (Horizontal < -0.25) //if walking left do this
            {
                animator.Play("PlayerWalk");

            }
            //If standing still
            if (Horizontal == 0)
            {
                //Standing still
                if (isCursorCenter == true)
                {
                    animator.Play("IdleFront");
                }
                if(isCursorCenter == false)
                {
                    animator.Play("IdleSide");
                }
            }
        }


        //Checks if player is grounded
        if (Physics2D.OverlapBox(groundcheck.position, new Vector2(0.45f, 0.01f), 0, groundLayer))
        {

            mayJump = 0.33f; // coyote time
        } else
        {
            mayJump -= Time.deltaTime;
        }

        //Jump
        if(Input.GetButtonDown("Jump") && mayJump > 0.1) //if player hit the jump button with coyote time
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            mayJump = 0;
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.65f);
            mayJump = 0;
        }

    }

    public void FixedUpdate()
    {
        if(acceleration < 0)
        {
            rb.velocity = new Vector2(-Horizontal * Speed, rb.velocity.y);
        } else
        {
            rb.velocity = new Vector2(Horizontal * Speed, rb.velocity.y);
        }
    }

    private void faceFlip()
    {
        if(facingRight && Horizontal < 0f || !facingRight && Horizontal > 0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
