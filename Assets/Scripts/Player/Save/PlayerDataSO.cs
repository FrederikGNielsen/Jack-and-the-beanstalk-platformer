using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "PlayerInfo", order = 1)]
public class PlayerDataSO : ScriptableObject
{
    public int health;
    public int pebbles;
    public int level;
    public int beanStalkAmmo;
}