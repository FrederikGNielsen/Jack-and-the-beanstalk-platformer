using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "playerScriptable/PlayerData", order = 1)]
public class playerScriptable : ScriptableObject
{
    [Header("Movement")]
    public float speed;

    //Combat
    [Header("Combat")]
    public int rocks;
    public float knifeDamage;
}
