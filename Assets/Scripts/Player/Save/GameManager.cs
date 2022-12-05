using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int health = 25;
    public int pebbles = 10;
    public int SpecialPebbles1 = 0;
    public int SpecialPebbles2 = 0;
    public int SpecialPebbles3 = 0;

    public int nextLevel;
    public GameObject playerGO;

    Color lerpedColor = Color.white;
    void Start()
    {

    }


    public void saveData()
    {

    }

    public void loadData()
    {

    }

    public void Reset()
    {
        //health = data.health;
        //pebbles = data.pebbles;
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
