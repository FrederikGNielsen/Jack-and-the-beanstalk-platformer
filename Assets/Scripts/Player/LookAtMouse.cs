using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;
using System.Runtime.CompilerServices;

public class LookAtMouse : MonoBehaviour
{
    public TMP_Text mouseText;
    public GameObject player;
    void Start()
    {
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        float screenWidth = Screen.width;
        float RightPos = screenWidth - screenWidth / 3 * 2;
        float Center = screenWidth - screenWidth / 3 * 2;
        float leftPos = screenWidth + screenWidth / 3 * 2;


        if (mousePos.x < leftPos)
        {
            Debug.Log("Left");
            GetComponent<playerAttack>().AttackDirection(true);
            Vector3 localScale = transform.localScale;
            localScale.x = 1.5f;
            transform.localScale = localScale;
        }
        else if (mousePos.x < RightPos)
        {
            Debug.Log("Right");
            GetComponent<playerAttack>().AttackDirection(false);
            Vector3 localScale = transform.localScale;
            localScale.x = -1.5f;
            transform.localScale = localScale;
        }
    }
}
