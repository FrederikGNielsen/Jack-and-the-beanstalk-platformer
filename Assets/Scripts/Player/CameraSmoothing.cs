using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothing : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector3 offset;

    public void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Slerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
