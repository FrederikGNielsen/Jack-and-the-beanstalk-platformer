using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public float health = 25;
    public int pebbles = 10;
    public int SpecialPebbles1 = 0;
    public int SpecialPebbles2 = 0;
    public int SpecialPebbles3 = 0;
}
