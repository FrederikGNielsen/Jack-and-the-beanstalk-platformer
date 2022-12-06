using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public PlayerDataSO Data;
    public GameObject PlayerGO;

    public int health;
    public int pebbles;
    public int level;
    public int beanStalkAmmo;

    public TMPro.TMP_Text stoneText;

    //UI
    public 

    void Start()
    {
        loadData();
    }

    void Update()
    {
        stoneText.text = "Pebbles: " + pebbles;
    }

    public void loadData()
    {
        //Loads variables from SO
        health = Data.health;
        pebbles = Data.pebbles;
        level = Data.level;
        beanStalkAmmo= Data.beanStalkAmmo;
    }

    public void saveData()
    {
        Data.health = health;
        Data.pebbles = pebbles;
        Data.level = level;
        Data.beanStalkAmmo = beanStalkAmmo;
    }


    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            ResetLevel();
            Debug.Log("Dead");
        }
    }

    public void addPebbles(int amount)
    {
        pebbles += amount;
    }

    public void removePebbles(int amount)
    {
        pebbles -= amount;
    }

    public void Nextlevel()
    {
        saveData();
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
        level += 1;
    }

    public void ResetLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 0;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
