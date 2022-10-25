using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CrateDrop", menuName = "crateScriptableObject/CrateDrop", order = 1)]
public class crateScriptableObject : ScriptableObject
{
    public GameObject dropGameObject;
    public float dropChance;
    public int minDrop;
    public int maxDrop;
}
