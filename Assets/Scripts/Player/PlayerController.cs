using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Mini Singleton ;)
    public static PlayerController Ins;
    private void Awake()
    {
        Ins = this;
    }
    //
    public bool joyMode { get; set; }
    public PlayerInput PlayerInput => playerInput;
    
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private LayerMask walkableLayer;
    private Vector2 _moveInput;
    private Vector2 _rotInput;

    #region WASD / Joy Move

    public void OnMove(InputValue inputValue)
    {

        _moveInput = inputValue.Get<Vector2>();
        Debug.Log(_moveInput);

        
        
        
    } 
    public void OnRotate(InputValue inputValue)
    {
        _rotInput = inputValue.Get<Vector2>();
        Debug.Log(_rotInput);

    }

    private void Update()
    {
        CameraController.Ins.MainCam.transform.eulerAngles += Vector3.up * _rotInput.x * 10;
        if (!Mouse.current.leftButton.isPressed && joyMode)
        {
            _rotInput = Vector2.zero;
        }
        
        if (_moveInput == Vector2.zero)
            return;

        var camEuler = Camera.main.transform.eulerAngles;
        camEuler.x = 0;

        var moveDir = Quaternion.Euler(camEuler) * new Vector3(_moveInput.x, 0, _moveInput.y);

        transform.position += moveDir * (moveSpeed * Time.deltaTime);

        transform.rotation = Quaternion.LookRotation(moveDir);


        if (!Mouse.current.leftButton.isPressed && joyMode)
        {
            _moveInput = Vector2.zero;
        }
    }

    #endregion
    

    #region Hit And Go Move

    public void OnTap(InputValue inputValue)
    {
        Debug.Log("tapped");
        var mousePos = Mouse.current.position.ReadValue();

        Ray ray = CameraController.Ins.MainCam.cam.ScreenPointToRay(mousePos);

        // Debug.DrawRay(ray.origin,ray.direction*100);
        // Debug.Break();

        if (Physics.Raycast(ray, out var hit, 1000, walkableLayer))
        {
            MoveToTarget(hit.point);
        }

    }

    public void MoveToTarget(Vector3 pos)
    {
        StopCoroutine(nameof(MoveToTargetSequence));
        StartCoroutine(nameof(MoveToTargetSequence),pos);
    }
    IEnumerator MoveToTargetSequence(Vector3 pos)
    {
        transform.LookAt(pos);
        
        var distanceToStop = .5f;
        var distanceToTarget = Mathf.Infinity;
        
        while (distanceToTarget > distanceToStop)
        {
            distanceToTarget = Vector3.Distance(transform.position, pos);

            transform.position = Vector3.MoveTowards(transform.position, pos, moveSpeed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }
    
    #endregion

    // private void LateUpdate()
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(Pointer.current.position.value);
    //     
    //     Debug.DrawRay(ray.origin,ray.direction*1000,Color.red);
    // }
}
