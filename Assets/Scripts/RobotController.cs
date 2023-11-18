using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    Rigidbody _rb;
    bool _jump;
    bool _canJump;
    bool _canMove = true;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpSpeed = 5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (!_canMove) return;
        var cameraController = Camera.main.GetComponent<CameraController>();
        if (!cameraController.IsOrthographicView())
        {
            return;
        }
        var horizontal = Input.GetAxis("Horizontal");

        switch(cameraController._currentView)
        {
            case CameraController.View.FirstView:
                transform.Translate(horizontal * Time.deltaTime * _moveSpeed, 0, 0);
                break;
            case CameraController.View.SecondView:
                transform.Translate(0, 0, horizontal * Time.deltaTime * _moveSpeed);
                break;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_jump && _canJump)
        {
            _jump = true;
        }
    }

    private void FixedUpdate()
    {
        if (_jump)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
        _jump = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (_canJump) return;

        _canJump = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        _canJump = false;
    }

    internal void DisableMovement()
    {
        _canMove = false;
    }

    internal void EnableMovement()
    {
        _canMove = true;
    }
}
