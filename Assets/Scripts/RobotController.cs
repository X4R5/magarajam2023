using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    Rigidbody _rb;
    bool _jump;

    [SerializeField] private float _jumpSpeed = 5f;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (!ViewManager.Instance.CanAction()) return;

        var horizontal = Input.GetAxis("Horizontal");

        switch(ViewManager.Instance._currentView)
        {
            case ViewManager.View.FirstView:
                transform.Translate(horizontal * Time.deltaTime * 5f, 0, 0);
                break;
            case ViewManager.View.SecondView:
                transform.Translate(0, 0, horizontal * Time.deltaTime * 5f);
                break;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_jump)
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
}
