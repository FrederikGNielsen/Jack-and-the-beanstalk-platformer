using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public bool isWalking;
    public bool isAttacking;
    public bool isCharging;
    public bool isCarryingGoose;

    public bool isCursorCenter;

    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAttacking)
        {
            if (isWalking)
            {
                if (isCharging)
                {
                    if (isCarryingGoose)
                    {
                        animator.Play("GooseSlingshotWalk");
                    }
                    else
                    {
                        animator.Play("SlingshotWalk");
                    }
                }
                else if (isCarryingGoose)
                {
                    animator.Play("GooseWalk");
                }
                else
                {
                    animator.Play("PlayerWalk");
                }
            }
            else
            {
                if (isCharging)
                {
                    if (isCarryingGoose)
                    {
                        animator.Play("GooseSlingshotStill");
                    }
                    else
                    {
                        animator.Play("SlingshotStill");
                    }
                }
                else if (isCarryingGoose)
                {
                    animator.Play("GooseIdle");
                }
                if (isCursorCenter)
                {
                    if (!isCharging)
                    {
                        if(!isCarryingGoose)
                        {
                            animator.Play("IdleFront");
                        }
                    }
                }
                else
                {
                    if (!isCharging)
                    {
                        if(!isCarryingGoose)
                        {
                            animator.Play("IdleSide");
                        }
                    }
                }
            }
        } else
        {
            if(isCarryingGoose)
            {
                animator.Play("PlayerAttackWithGoose");
            } else
            {
                animator.Play("PlayerAttack");
            }
        }
    }
}
