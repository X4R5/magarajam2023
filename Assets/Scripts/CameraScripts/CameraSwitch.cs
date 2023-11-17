using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] GameObject _cameraToSwitch;
    [SerializeField] GameObject _wallToDisable, _wallToEnable;
    Animator _animator;


    bool _isSwitching = false;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnSwitchAnimationStart()
    {
        _wallToDisable.SetActive(false);
    }

    public void OnSwitchAnimationEnd()
    {
        _cameraToSwitch.SetActive(true);
        _animator.SetTrigger("pass");
        gameObject.SetActive(false);
        _wallToEnable.SetActive(true);
    }

    public bool IsSwitching()
    {
        return _isSwitching;
    }
}
