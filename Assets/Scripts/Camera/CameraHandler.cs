using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public  float followSpeed = 10;
    public  Transform target ;
    public  bool rotateWithPlayer ;
    public Camera cam;

    public virtual void LateUpdate()
    {
        var finalPos = target.position ;

        transform.position = Vector3.Lerp(transform.position, finalPos, followSpeed * Time.deltaTime);

        if (rotateWithPlayer && !PlayerController.Ins.joyMode)
        {

            transform.rotation= Quaternion.Lerp(transform.rotation,target.rotation, Time.deltaTime);
        }
    }
}
