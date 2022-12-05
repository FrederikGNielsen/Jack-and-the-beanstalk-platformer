using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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
        GM.GetComponent<PlayerData>().Nextlevel();
    }

}
