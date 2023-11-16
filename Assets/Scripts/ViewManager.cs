using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public static ViewManager Instance;

    public enum View
    {
        FirstView,
        SecondView
    }

    public View _currentView;

    [SerializeField] private Camera _firstCamera, _secondCamera;
    [SerializeField] Animation _firstCameraAnimation, _secondCameraAnimation;
    [SerializeField] private GameObject _firstWall, _secondWall;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _currentView = View.FirstView;
        _firstCamera.gameObject.SetActive(true);
        _secondCamera.gameObject.SetActive(false);
        _firstWall.SetActive(false);
        _secondWall.SetActive(true);
    }

    void Update()
    {
        if (CanAction())

        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeView();
        }
    }

    public bool CanAction()
    {
        if (_firstCamera.GetComponent<CameraSwitch>().IsSwitching() || _secondCamera.GetComponent<CameraSwitch>().IsSwitching())
            return false;
        else
            return true;
    }

    private void ChangeView()
    {
        switch (_currentView)
        {
            case View.FirstView:
                _currentView = View.SecondView;
                _firstCamera.GetComponent<Animator>().SetTrigger("switch");
                break;
            case View.SecondView:
                _currentView = View.FirstView;
                _secondCamera.GetComponent<Animator>().SetTrigger("switch");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
