using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6OutsideDoor : MonoBehaviour
{
    [SerializeField] ButtonController3D _buttonController3D;
    Animator _animator;
    bool _isOpened = false;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_buttonController3D.IsPressed())
        {
            if (_isOpened) return;
            _animator.SetTrigger("Level6Open");
            _isOpened = true;
        }
        else
        {
            if (!_isOpened) return;
            _animator.SetTrigger("Level6Close");
            _isOpened = false;
        }
    }
}
