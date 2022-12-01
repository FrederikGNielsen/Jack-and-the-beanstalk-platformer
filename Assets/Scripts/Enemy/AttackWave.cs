using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWave : MonoBehaviour
{
    public bool Left;
    public float speed;

    public GameObject collisionUp;
    public GameObject collisionDown;

    public LayerMask groundLayer;

    public ParticleSystem particleSystem;

    private int wavesDestroyed;
    public GameObject parent;
    public LayerMask playerLayer;

    public float damageCooldown;
    public float damageCooldownLeft;
    public GameObject damageDetection;

    public GameObject otherWave;

    public GameObject GM;

    public float detectRange;
    void Start()
    {
        GM = GameObject.Find("GM");
    }

    // Update is called once per frame
    void Update()
    {
        //cooldown timer
        if(damageCooldownLeft > 0)
        {
            damageCooldownLeft -= Time.deltaTime;
        }


        if(Left == false)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        } else
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }

        if(Physics2D.OverlapCircle(collisionUp.transform.position, detectRange, groundLayer))
        {
            particleSystem.Stop();
            if (wavesDestroyed == 0)
            {
                otherWave.GetComponent<AttackWave>().wavesDestroyed += 1;
            }
            else
            {
                Destroy(parent, 0.25f);
            }
            Destroy(this.gameObject, .25f);
           
        }
        if (Physics2D.OverlapCircle(collisionDown.transform.position, detectRange, groundLayer))
        {
            particleSystem.Stop();
            if(wavesDestroyed== 0)
            {
                otherWave.GetComponent<AttackWave>().wavesDestroyed += 1;
            } else
            {
                Destroy(parent, 0.25f);
            }
            Destroy(this.gameObject, .25f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(damageCooldownLeft <= 0)
            {
                Debug.Log("Hit player");
                GM.GetComponent<PData>().removeHealth(5);
                damageCooldownLeft = damageCooldown;
            }
        }
    }
}
