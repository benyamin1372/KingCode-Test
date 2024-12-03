using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private float followSpeed = 10;
    [SerializeField] private Vector3 offset ;
    [SerializeField] private Transform target ;


    public void LateUpdate()
    {
        var finalPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, finalPos, followSpeed * Time.deltaTime);
    }
}
