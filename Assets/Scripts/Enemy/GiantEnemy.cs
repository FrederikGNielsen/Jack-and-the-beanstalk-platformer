using JetBrains.Annotations;
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
    public bool turnedLeft;

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

    [Header("Player Detection")]
    public GameObject playerDetection;
    public float playerDetectionRadius;

    [Header("Collision Detection")]
    public GameObject CollisionDetectionWall;
    public GameObject CollisionDetectionFloor;
    public float CollisionDetectionnRadius;
    public LayerMask groundLayer;


    public AudioSource aSource;
    public AudioClip StompSFX;

    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerDetection.transform.position, playerDetectionRadius);
    }
    void Update()
    {
        if (!turnedLeft)
        {
            transform.localScale = new Vector3(1, 1, 1);
        } else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(walking)
        {
            if (turnedLeft == false)
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }
            if (Physics2D.OverlapCircle(CollisionDetectionWall.transform.position, CollisionDetectionnRadius, groundLayer))
            {
                Debug.Log("Touched wall turn around");
                if(turnedLeft)
                {
                    turnedLeft= false;
                } else
                {
                    turnedLeft= true;
                }
            }
            if (Physics2D.OverlapCircle(CollisionDetectionFloor.transform.position, CollisionDetectionnRadius, groundLayer))
            {
                Debug.Log("Close to edge");
                if (turnedLeft)
                {
                    turnedLeft = false;
                }
                else
                {
                    turnedLeft = true;
                }
            }
        }


        //if not staggered
        if(staggered == false) {
            if(!isAttacking) //if not staggered or attakcing
            {
                walking= true;
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
                walking= false;
                if(attackTimeLeft < 0.5 && !attackWaveSound)
                {
                    aSource.clip = StompSFX;
                    aSource.Play();
                    attackWaveSound = true;
                }
                if(attackTimeLeft < 0.3 && !attackWave)
                {
                    Debug.Log("Ground stomp");
                    Instantiate(AttackWave, WavePosition.transform);
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
                walking= false;
            }
            else
            {
                //Debug.Log("No Longer staggered");
                staggered = false;
                walking= true;
            }
        }
        if(!happy)
        {
            if (angryTimeLeft > 0)
            {
                angryTimeLeft -= Time.deltaTime;
                speed = 2f;
                if(!isAttacking)
                {
                    int randomNumber = Random.Range(0, 1000);
                    if (randomNumber == 1)
                    {
                        isAttacking = true;
                    }
                }
            }
            else
            {
                //Debug.Log("No Longer staggered");
                happy = true;
                speed = 1f;
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
