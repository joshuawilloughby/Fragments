using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;

    public float followSpeed = 2f;
    public float zValue = -30;

    public float yValue = 10;
 
    void FixedUpdate()
    {
        Vector3 newPosition = target.position;
        newPosition.z = zValue;
        newPosition.y = yValue;
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    } 
}
