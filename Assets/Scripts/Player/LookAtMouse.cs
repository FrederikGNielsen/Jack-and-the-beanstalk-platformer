using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;

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

        if(mousePos.x > Screen.width / 2.0f)
        {
            GetComponent<playerAttack>().AttackDirection(true);
            Vector3 localScale = transform.localScale;
            localScale.x = 1.5f;
            transform.localScale = localScale;
        } else
        {
            GetComponent<playerAttack>().AttackDirection(false);
            Vector3 localScale = transform.localScale;
            localScale.x = -1.5f;
            transform.localScale = localScale;
        }
    }
}
