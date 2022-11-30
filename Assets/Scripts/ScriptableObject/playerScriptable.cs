using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "playerScriptable/PlayerData", order = 1)]
public class playerScriptable : ScriptableObject
{
    [Header("Movement")]
    public float health;

    //Combat
    [Header("Combat")]
    public int pebbles;
    public int SpecialPebbles1;
    public int SpecialPebbles2;
    public int SpecialPebbles3;
    public float knifeDamage;
}
