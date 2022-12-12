using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private Animator animator;

    public float timer;

    private bool RandomStomp;
    private bool footIsUp;
    private bool isStomping;

    private GameObject bParent;

    public GameObject Indicator;

    public void Start()
    {
        bParent = GameObject.Find("BossParent");
        animator = GetComponent<Animator>();
        Indicator.SetActive(false);
        RandomAttack();
    }


    private void Update()
    {
        if (RandomStomp)
        {
            //Bools
            footIsUp = false;


            Indicator.transform.position = new Vector3(gameObject.transform.position.x, Indicator.transform.position.y, Indicator.transform.position.z);
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                Indicator.SetActive(false);
                animator.Play("BossIdle");
            }

            //Idle when in air
            if (timer < 9 && timer > 8.5f && !footIsUp)
            {
                footIsUp = true;
                animator.Play("BossFootUp");
            }

            //stomp after certain amount of time
            if (timer < 6 && timer > 5.5f && !isStomping)
            {
                Indicator.SetActive(true);
                isStomping = true;

                //Random number for random transform
                float randomX = Random.Range(15.00f, 25.00f);

                //Changes transform x to something random
                bParent.transform.position = new Vector3(randomX, bParent.transform.position.y, bParent.transform.position.z);

                //Animation
                animator.Play("RandomStompDown");
            }

            //When boss stomps idle for a few seconds
            if (timer < 5.8f && timer > 5f)
            {
                //Animation
                animator.Play("BossIdle");
            }
            if (timer < 3f && timer > 2.8f)
            {
                //Animation
                animator.Play("RandomStompUp");
            }


            if (timer < 2f && timer > 1.9f)
            {
                //Animation
                bParent.transform.position = new Vector3(28.4f, bParent.transform.position.y, bParent.transform.position.z);
                isStomping = true;
                animator.Play("RandomStompDown");
            }
            if (timer < 1.8f && timer > 1f)
            {
                //Animation
                animator.Play("BossIdle");
            }
            if (timer < 0.1f && timer > 0f)
            {
                //Animation
                RandomStomp = false;
                RandomAttack();
            }
        }
    }

    public void RandomAttack()
    {
        int AttackNumber = Random.Range(1, 1);

        if(AttackNumber == 1) //Random stomp
        {
            Debug.Log("Attack 1");

            animator.Play("RandomStompUp");
            isStomping = false;
            RandomStomp = true;
            timer = 10f;
        }
        if (AttackNumber == 2) //Stomp rock fall
        {
            Debug.Log("Attack ´2");
        }
        if (AttackNumber == 3) //Gas cloud
        {
            Debug.Log("Attack 3");
        }
    }
}
