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

    public GameObject otherWave;

    public float detectRange;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Left == false)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        } else
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if(Physics2D.OverlapCircle(collisionUp.transform.position, detectRange, groundLayer))
        {
            Debug.Log("Hit something");
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
            Debug.Log("no Longer touching ground");
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
}
