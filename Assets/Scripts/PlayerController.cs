using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;
    private Vector2 _moveInput;
    
    public void OnMove(InputValue inputValue)
    {
        _moveInput = inputValue.Get<Vector2>();
        Debug.Log(_moveInput);

        
        
        
    }
    private void Update()
    {
        if (_moveInput == Vector2.zero)
            return;
        
        var moveDir = transform.rotation * new Vector3(_moveInput.x, 0, _moveInput.y);

        transform.position += moveDir * (moveSpeed * Time.deltaTime);
    }

    public void MoveToTarget(Vector3 pos)
    {
        StopCoroutine(nameof(MoveToTargetSequence));
        StartCoroutine(nameof(MoveToTargetSequence),pos);
    }


    public void OnTap(InputValue inputValue)
    {
        Debug.Log(inputValue.Get<Vector2>());
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
}
