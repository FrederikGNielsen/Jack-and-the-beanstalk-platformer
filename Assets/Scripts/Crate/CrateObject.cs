using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateObject : MonoBehaviour
{
    public float health;

    public void Start()
    {
        
    }

    public void takeDamage(float amount)
    {
        health -= amount;
        if (health < 0)
        {
            Debug.Log("Destroy");
            Destroy(this.gameObject);
        }
    }
}
