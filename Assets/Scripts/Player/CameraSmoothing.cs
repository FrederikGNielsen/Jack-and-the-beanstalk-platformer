using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothing : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector3 offset;
    public float dampening;
    private Vector3 Shake;

    public void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;
        mousePos.x = mousePos.x / dampening;
        mousePos.y = mousePos.y / dampening;
        Vector3 TestVector = new Vector3(mousePos.x, mousePos.y, 0);
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Slerp(transform.position, targetPosition + TestVector + Shake, smoothing * Time.deltaTime);
    }
}
