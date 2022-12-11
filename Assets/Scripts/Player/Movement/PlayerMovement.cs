using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Walk")]
    public float Horizontal;
    private bool facingRight = true;
    public float Speed;

    [Header("Jump")]
    public float jumpHeight;
    public float mayJump;
    public bool isGrounded;
    public Transform groundcheck;
    public float radius;
    public LayerMask groundLayer;

    public GameObject AM;
    public Rigidbody2D rb;

    //Animations
    public bool isCursorCenter;
    public bool isWalking;

    //Audio
    public AudioSource aSource;
    public AudioClip JumpSound;
    public AudioClip AttackSwoosh;


    void Update()
    {
        //Left and Right input
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (this.GetComponent<playerAttack>().isAttacking == false)
        {
            if (Horizontal > 0.25) //If walking right do this
            {
                AM.GetComponent<AnimationManager>().isWalking = true;

            }
            if (Horizontal < -0.25) //if walking left do this
            {
                AM.GetComponent<AnimationManager>().isWalking = true;

            }
            //If standing still
            if (Horizontal == 0)
            {
                AM.GetComponent<AnimationManager>().isWalking = false;
            }
        }

        //Checks if player is grounded
        if (Physics2D.OverlapBox(groundcheck.position, new Vector2(0.45f, 0.01f), 0, groundLayer))
        {

            mayJump = 0.33f; // coyote time
        }
        else
        {
            mayJump -= Time.deltaTime;
        }

        //Jump
        if (Input.GetButtonDown("Jump") && mayJump > 0.1) //if player hit the jump button with coyote time
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            aSource.clip = JumpSound;
            aSource.Play();
            mayJump = 0;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.65f);
            mayJump = 0;
        }

    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2(Horizontal * Speed, rb.velocity.y);
    }

    private void faceFlip()
    {
        if (facingRight && Horizontal < 0f || !facingRight && Horizontal > 0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}