using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class playerAttack : MonoBehaviour
{
    public GameObject Knife;
    public Animator animator;
    public Animator playerAnimator;

    public Transform attackPos;
    public LayerMask enemiesLayer;
    public LayerMask crateLayer;
    public float attackRange;
    public int damage;

    private GameObject AM;

    public bool isAttacking;
    public bool isCharging;
    public bool carryingGoose;

    private bool isTurnedRight;

    //Shake
    public GameObject MainCam;
    public float minShake;
    public float maxShake;

    void Start()
    {
        AM = GameObject.Find("AnimationManager");
        Knife.SetActive(true);
        animator.SetFloat("Right", 1);
        Knife.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isCharging = GameObject.Find("Slingshot").GetComponent<Slingshot>().isCharging;
        Knife.transform.position = transform.position;
        if(Input.GetButtonDown("Fire1"))
        {
            if(!isCharging)
            {
                AM.GetComponent<AnimationManager>().isAttacking = true;
                Knife.SetActive(true);
                isAttacking = true;
                StartCoroutine(Sword());

                //Checks if hitting crate and damages if hit
                Collider2D[] cratesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, crateLayer);
                for (int i = 0; i < cratesToDamage.Length; i++)
                {
                    cratesToDamage[i].GetComponent<CrateObject>().takeDamage(damage);
                }


                //Checks if hitting enemy and damages if hit
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemiesLayer);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    if (enemiesToDamage[i].gameObject.tag == "Giant")
                    {
                        if (enemiesToDamage[i].GetComponent<GiantEnemy>().staggered) // if giant is staggered attack
                        {
                            enemiesToDamage[i].GetComponent<GiantEnemy>().attackedWhileStaggered();
                        }
                        else
                        {
                            enemiesToDamage[i].GetComponent<GiantEnemy>().attackeWhileNotStaggered();
                            Debug.Log("Hit Giant while it wasn't staggered");
                        }
                    }
                }
            }
        } 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    IEnumerator Sword()
    {
        yield return new WaitForSeconds(0.15f);
        Knife.SetActive(false);
        isAttacking = false;
        AM.GetComponent<AnimationManager>().isAttacking = false;
    }
}
