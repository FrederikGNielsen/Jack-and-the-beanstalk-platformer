using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GiantEnemy : MonoBehaviour
{
    public float speed;
    public float health;

    //Stagger variables
    [Header("Staggered")]
    public bool staggered;
    public float staggerTimeLeft;
    public float staggerTime;
    [Header("Happy and angry")]
    public bool happy;
    public float angryTimeLeft;
    public float angryTime;
    public float angryAttackTime;
    public float angryAttackTimeLeft;


    public bool walking;
    [Header("Attacking")]
    public bool isAttacking;
    public float attackTimeLeft;
    public float attackTime;

    [Header("Attack wave")]
    public bool attackWave;
    public bool attackWaveSound;
    public GameObject AttackWave;
    public GameObject WavePosition;
    public Animator animator;

    public AudioSource aSource;
    public AudioClip StompSFX;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if not staggered
        if(staggered == false) {
            if(!isAttacking) //if not staggered or attakcing
            {
                if (happy == true) //Check if the enemy is happy
                {
                    //Debug.Log("Walking Happy");
                    if (walking == true)
                    {
                        //Debug.Log("Walking Happy");
                        animator.Play("EnemyWalkHappy");
                    }
                    else
                    {
                        animator.Play("Idle");
                    }

                }
                if (happy == false) //Checks if the enemy is angry
                {
                    //Debug.Log("Walking Angry");
                    if (walking == true)
                    {
                        //Debug.Log("Walking Happy");
                        animator.Play("EnemyWalkAngry");
                    }
                    else
                    {
                        animator.Play("Idle");
                    }
                };
            } else // if is attacking
            {
                if(attackTimeLeft < 0.5 && !attackWaveSound)
                {
                    aSource.clip = StompSFX;
                    aSource.Play();
                    attackWaveSound = true;
                }
                if(attackTimeLeft < 0.3 && !attackWave)
                {
                    Debug.Log("Ground stomp");
                    Instantiate(AttackWave);
                    attackWave = true;
                }
                if (attackTimeLeft > 0)
                {
                    attackTimeLeft -= Time.deltaTime;
                    animator.Play("EnemyAttack");
                }
                else
                {
                    //Debug.Log("No Longer staggered");
                    isAttacking = false;
                    attackWave = false;
                    attackWaveSound= false;
                }
            }
        }
        else
        {
            if (staggerTimeLeft > 0)
            {
                staggerTimeLeft -= Time.deltaTime;
                animator.Play("EnemyStaggered");
            }
            else
            {
                //Debug.Log("No Longer staggered");
                staggered = false;
            }
        }
        if(!happy)
        {
            if (angryTimeLeft > 0)
            {
                angryTimeLeft -= Time.deltaTime;
            }
            else
            {
                //Debug.Log("No Longer staggered");
                happy = true;
            }
        }
    }

    public void StaggerGiant()
    {
        staggered = true;
        staggerTimeLeft = staggerTime;
    }

    public void Attack()
    {
        isAttacking = true;
        Angry();
        attackTimeLeft = attackTime;
    }

    public void Angry()
    {
        happy = false;
        angryTimeLeft = angryTime;
    }

    public void attackedWhileStaggered()
    {

    }

    public void attackeWhileNotStaggered()
    {
        Attack();
    }
}
