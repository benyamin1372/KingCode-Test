using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    
    //Mini Singleton ;)
    public static UIController Ins;
    private void Awake()
    {
        Ins = this;
    }
    //


    [SerializeField] private GameObject joy;

    public void SetActiveJoy(bool active)
    {
        joy.SetActive(active);
    }
}
