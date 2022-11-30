using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{

    public int level;
    public float health;
    public int pebbles;
    public int SpecialPebbles1;
    public int SpecialPebbles2;
    public int SpecialPebbles3;
    public float knifeDamage;



    public PlayerData(Player player)
    {
        level = player.level;
        health = player.health;
        pebbles = player.pebbles;
        SpecialPebbles1= player.SpecialPebbles1;
        SpecialPebbles2= player.SpecialPebbles2;
        SpecialPebbles3= player.SpecialPebbles3;
        knifeDamage= player.knifeDamage;
    }
}
