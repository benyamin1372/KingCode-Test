using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private void Start()
    {
        SwitchToJoy();

    }

    private void Update()
    {
        if (Keyboard.current.numpad1Key.wasPressedThisFrame)
        {
            SwitchTo3rd();
        }
        if (Keyboard.current.numpad2Key.wasPressedThisFrame)
        {
            SwitchToTopDown();
        }
        if (Keyboard.current.numpad3Key.wasPressedThisFrame)
        {
            SwitchToJoy();
        }
    }

    void SwitchTo3rd()
    {
        CameraController.Ins.SwitchTo3rd();
        UIController.Ins.SetActiveJoy(false);
        PlayerController.Ins.PlayerInput.SwitchCurrentActionMap("Player WASD");
        PlayerController.Ins.PlayerInput.ActivateInput();

        PlayerController.Ins.joyMode = false;

    }
    void SwitchToTopDown()
    {
        CameraController.Ins.SwitchToTopDown();
        UIController.Ins.SetActiveJoy(false);
        PlayerController.Ins.PlayerInput.SwitchCurrentActionMap("Player Tap");
        PlayerController.Ins.PlayerInput.ActivateInput();
        PlayerController.Ins.joyMode = false;


    }
    void SwitchToJoy()
    {
        CameraController.Ins.SwitchTo3rd();
        UIController.Ins.SetActiveJoy(true);
        PlayerController.Ins.PlayerInput.SwitchCurrentActionMap("Player Joy");
        PlayerController.Ins.PlayerInput.ActivateInput();

        PlayerController.Ins.joyMode = true;

    }
}
