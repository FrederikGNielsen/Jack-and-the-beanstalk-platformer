using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float health = 25;
    public int pebbles = 10;
    public int SpecialPebbles1 = 0;
    public int SpecialPebbles2 = 0;
    public int SpecialPebbles3 = 0;

    public int nextLevel;


    public PlayerData data;
    public GameObject playerGO;
    void Start()
    {
        health = data.health;
        pebbles = data.pebbles;
        playerGO = GameObject.FindWithTag("Player");
        playerGO.GetComponent<Player>().pebbles = data.pebbles;
        playerGO.GetComponent<Player>().health = data.health;
    }

    public void saveData()
    {
        data.pebbles = playerGO.GetComponent<Player>().pebbles;
        data.health = playerGO.GetComponent<Player>().health;
    }

    public void loadData()
    {
        playerGO.GetComponent<Player>().pebbles = data.pebbles;
        playerGO.GetComponent<Player>().health = data.health;
    }

    public void Reset()
    {
        health = data.health;
        pebbles = data.pebbles;
        loadData();
    }

    public void NextLevel()
    {
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCount > nextLevel)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
