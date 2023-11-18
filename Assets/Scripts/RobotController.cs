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
    AudioSource _audioSource;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (!_canMove)
        {
            _audioSource.Stop();
            return;
        }
        var cameraController = Camera.main.GetComponent<CameraController>();
        if (!cameraController.IsOrthographicView())
        {
            _audioSource.Stop();
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

        if(Mathf.Abs(horizontal) > 0.01f)
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
        else
        {
            _audioSource.Stop();
        }
    }

    internal void DisableMovement()
    {
        _canMove = false;
        _audioSource.Stop();
    }

    internal void EnableMovement()
    {
        _canMove = true;
    }
}
