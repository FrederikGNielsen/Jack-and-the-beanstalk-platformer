using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantThrowing : MonoBehaviour
{
    public GameObject target;
    private Rigidbody2D rb;
    public LayerMask playerLayer;
    public bool hasThrown;
    public float timeNextThrow;
    public GameObject boulder;

    Vector3 calcBallisticVelocityVector(Vector3 source, Vector3 target, float angle)
    {
        Vector3 direction = target - source;
        float h = direction.y;
        direction.y = 0;
        float distance = direction.magnitude;
        float a = angle * Mathf.Deg2Rad;
        direction.y = distance * Mathf.Tan(a);
        distance += h / Mathf.Tan(a);

        // calculate velocity
        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * direction.normalized;
    }




    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(calcBallisticVelocityVector(transform.position, target.transform.position, 250));
    }

    public void Update()
    {
        if(Physics2D.OverlapCircle(transform.position, 5, playerLayer))
        {
            if(!hasThrown)
            {
                
                hasThrown = true;
                timeNextThrow = 5;
                Debug.Log("throw rock");
                GameObject boulderGO = Instantiate(boulder, transform.position, Quaternion.identity);
                rb.AddForce(calcBallisticVelocityVector(transform.position, target.transform.position, 33) * 50);
            } else
            {
                if(timeNextThrow <= 0)
                {
                    hasThrown= false;
                }
            }
            if (timeNextThrow > 0)
            {
                timeNextThrow -= Time.deltaTime;
            }
        }


        if(Input.GetKeyDown(KeyCode.O))
        {
            rb.AddForce(calcBallisticVelocityVector(transform.position, target.transform.position, 33) * 50);
        }
    }
}
