using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class PlayerData : MonoBehaviour
{
    public PlayerDataSO Data;
    public GameObject PlayerGO;

    public int health;
    public int pebbles;
    public int level;
    public int beanStalkAmmo;

    public TMPro.TMP_Text stoneText;
    public TMPro.TMP_Text healthText;

    //UI
    public 

    void Start()
    {
        loadData();
        stoneText = GameObject.Find("PebblesUI").GetComponentInChildren<TMPro.TMP_Text>();
        healthText = GameObject.Find("HealthUI").GetComponentInChildren<TMPro.TMP_Text>();
    }

    void Update()
    {
        stoneText.text = "Pebbles: " + pebbles;
        healthText.text = "Health: " + health;
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
