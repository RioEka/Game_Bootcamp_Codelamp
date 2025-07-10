using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    public float offsetY = 2f;
    public Transform target;
    void Update()
    {
        Vector3 newPosition = new Vector3(target.position.x, target.position.y + offsetY, -10f);
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
    }
}
