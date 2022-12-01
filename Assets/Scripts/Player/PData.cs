using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PData : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int pebbles;

    public PdataSO Data;
    void Start()
    {
        loadData();
    }

    private void OnApplicationQuit()
    {
        saveData();
    }

    public void loadData()
    {
        health = Data.health;
        pebbles= Data.pebbles;

    }

    public void saveData()
    {
        Data.health = health;
        Data.pebbles= pebbles;
    }

    public void removeHealth(int amount)
    {
        health -= amount;
        Data.health = health;
    }

    public void AddHealth(int amount)
    {
        health += amount;
        Data.health = health;
    }
}
