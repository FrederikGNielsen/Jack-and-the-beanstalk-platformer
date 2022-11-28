using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform targetPoint1, targetPoint2, currentTarget;

    public bool left;

    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = currentTarget.position - transform.position;
        direction.Normalize();
        transform.position += direction * Time.deltaTime * speed;

        if (Vector3.Distance(currentTarget.position, transform.position) <= .1f)
        {
            if (currentTarget == targetPoint1)
            {
                currentTarget = targetPoint2;
                Debug.Log("Target point 1 Reached");
            }
            else if (currentTarget == targetPoint2)
            {
                currentTarget = targetPoint1;
                Debug.Log("Target point 2 Reached");
            }
        }
    }
}
