using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoldenGoose : MonoBehaviour
{
    public GameObject AM;

    // Update is called once per frame
    void Start()
    {
        AM = GameObject.Find("AnimationManager");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            AM.GetComponent<AnimationManager>().isCarryingGoose = true;
            Destroy(gameObject);
        }
    }

}
