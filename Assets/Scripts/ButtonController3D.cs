using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController3D : MonoBehaviour
{
    Animator _animator;
    bool _isPressed = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetTrigger("Pressed");
            _isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetTrigger("Unpressed");
            _isPressed = false;
        }
    }

    public bool IsPressed()
    {
        return _isPressed;
    }
}
