using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private Animator animator;

    public float timer;

    public bool RandomStomp;

    public bool footIsUp;

    public GameObject Indicator;

    public void Start()
    {
        animator = GetComponent<Animator>();
        Indicator.SetActive(false);
        RandomAttack();
    }


    private void Update()
    {
        if(RandomStomp)
        {
            //Bools
            footIsUp= false;


            Indicator.SetActive(true);
            Indicator.transform.position = new Vector3(gameObject.transform.position.x, Indicator.transform.position.y, Indicator.transform.position.z);
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            } else
            {
                Indicator.SetActive(false);
                animator.Play("BossIdle");
            }

            if(timer < 9 && timer > 8.5f && !footIsUp)
            {
                footIsUp = true;
                animator.Play("BossFootUp");
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
