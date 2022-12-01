using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerMovement : MonoBehaviour
{
    [Header("Walk")]
    public float Horizontal;
    private bool facingRight = true;

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
            if(Horizontal > 0.25)
            {
                //Walking right
                animator.Play("PlayerWalk");

            }
            if (Horizontal < -0.25)
            {
                //Walking Left
                animator.Play("PlayerWalk");

            }
            if (Horizontal == 0)
            {

                //Standing still
                if (isCursorCenter == true)
                {
                    animator.Play("IdleFront");
                }
                if (isCursorCenter == false)
                {
                    animator.Play("IdleSide");
                }
            }
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
