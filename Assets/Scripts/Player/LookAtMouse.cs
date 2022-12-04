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

    public GameObject AM;

    public bool PointLeft;
    void Start()
    {
        AM = GameObject.Find("AnimationManager");
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        float screenWidth = Screen.width;
        float RightPosIdle = (screenWidth / 3) * 2 - ((screenWidth / 100) * 10);
        float LeftPosIdle = (screenWidth / 3) + ((screenWidth / 100) * 10);

        

        //Idle look side or center
        if (mousePos.x < LeftPosIdle)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = -1.4f;
            PointLeft = false;
            transform.localScale = localScale;
            AM.GetComponent<AnimationManager>().isCursorCenter = false;
        }
        else if (mousePos.x > RightPosIdle)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = 1.4f;
            PointLeft = true;
            transform.localScale = localScale;
            AM.GetComponent<AnimationManager>().isCursorCenter = false;
        }
        else
        {
            Vector3 localScale = transform.localScale;
            if (mousePos.x < screenWidth / 2)
            {
                localScale.x = -1.4f;
                PointLeft = false;
            }
            if (mousePos.x > screenWidth / 2)
            {
                localScale.x = 1.4f;
                PointLeft = true;
            }
            transform.localScale = localScale;
            AM.GetComponent<AnimationManager>().isCursorCenter = true;
        }
    }
}
