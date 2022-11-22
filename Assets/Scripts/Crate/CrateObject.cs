using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CrateObject : MonoBehaviour
{
    public float health;
    public GameObject Stone;


    public void Start()
    {
        
    }

    public void takeDamage(float amount)
    {
        health -= amount;
        if (health < 0)
        {
            destroyCrate();
            


        }
    }

    public void destroyCrate()
    {
        Debug.Log("Destroy");
        Destroy(this.gameObject);

        float Randomnumber = Random.Range(0.00f, 100.00f);
        if(Randomnumber < 25)
        {
            Debug.Log("Drop 1");
            Instantiate(Stone, this.transform.position, Quaternion.identity);
        } else if(Randomnumber < 50)
        {
            Debug.Log("Drop 1");
            Instantiate(Stone, this.transform.position, Quaternion.identity);
            Instantiate(Stone, this.transform.position, Quaternion.identity);
        } else if (Randomnumber < 75)
        {
            Debug.Log("Drop 1");
            Instantiate(Stone, this.transform.position, Quaternion.identity);
            Instantiate(Stone, this.transform.position, Quaternion.identity);
            Instantiate(Stone, this.transform.position, Quaternion.identity);
        }
        Destroy(this);
    }
}
