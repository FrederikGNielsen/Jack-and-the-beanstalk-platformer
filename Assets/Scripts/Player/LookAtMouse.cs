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
        float RightPosIdle = (screenWidth / 3) * 2 - ((screenWidth / 100) * 15);
        float LeftPosIdle = (screenWidth / 3) + ((screenWidth / 100) * 15);

        if (mousePos.x < screenWidth / 2)
        {
            GetComponent<playerAttack>().AttackDirection(false);
        }
        if (mousePos.x > screenWidth / 2)
        {
            GetComponent<playerAttack>().AttackDirection(true);

        }

        //Idle look side or center
        if (mousePos.x < LeftPosIdle)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = -1.5f;
            transform.localScale = localScale;
            GetComponent<PlayerMovement>().isCursorCenter= false;
        }
        else if (mousePos.x > RightPosIdle)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = 1.5f;
            transform.localScale = localScale;
            GetComponent<PlayerMovement>().isCursorCenter = false;
        }
        else
        {
            Vector3 localScale = transform.localScale;
            if (mousePos.x < screenWidth / 2)
            {
                localScale.x = -1.3f;
            }
            if (mousePos.x > screenWidth / 2)
            {
                localScale.x = 1.3f;
            }
            transform.localScale = localScale;
            GetComponent<PlayerMovement>().isCursorCenter = true;
        }
    }
}
