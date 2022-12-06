using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoldenGoose : MonoBehaviour
{
    public GameObject GM;

    // Update is called once per frame
    void Start()
    {
        GM = GameObject.Find("GM");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            GM.GetComponent<PlayerData>().Nextlevel();
        }
    }

}
