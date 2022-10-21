using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Walk")]
    private float Horizontal;
    private bool facingRight = true;
    public float Speed;

    [Header("Jump")]
    public float jumpHeight;
    public bool isGrounded;
    public Transform groundcheck;
    public float radius;
    public LayerMask groundLayer;

    public Rigidbody2D rb;
    

    void Update()
    {
        //Left and Right input
        Horizontal = Input.GetAxisRaw("Horizontal");

        //Checks if player is grounded
        if (Physics2D.OverlapBox(groundcheck.position, new Vector2(0.45f, 0.01f), 0, groundLayer))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }

        //Jump
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2(Horizontal * Speed, rb.velocity.y);
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
