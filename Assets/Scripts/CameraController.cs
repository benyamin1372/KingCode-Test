using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    //Mini Singleton ;)
    public static CameraController Ins;
    private void Awake()
    {
        Ins = this;
    }
    //

    [SerializeField] private CameraHandler camera3rd,cameraTopDown;

    public void SwitchTo3rd()
    {
        camera3rd.gameObject.SetActive(true);
        cameraTopDown.gameObject.SetActive(false);
    }
    
    public void SwitchToTopDown()
    {
        camera3rd.gameObject.SetActive(false);
        cameraTopDown.gameObject.SetActive(true);
    }
}