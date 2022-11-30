using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level;
    public float health;
    public int pebbles;
    public int SpecialPebbles1;
    public int SpecialPebbles2;
    public int SpecialPebbles3;
    public float knifeDamage;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer ()
    {
        SaveSystem.LoadPlayer();
    }
}
