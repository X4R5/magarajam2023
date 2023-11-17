using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform _target;
    public float _rotateSpeed = 2.0f;
    bool _canRotate = false;
    bool _canSwitch = true;

    [SerializeField] Transform _firstTransform, _secondTransform;
    [SerializeField] GameObject _firstWall, _secondWall;
    PerspectiveSwitcher _perspectiveSwitcher;
    Camera _camera;
    public enum View
    {
        FirstView,
        SecondView
    }

    public View _currentView;

    private void Start()
    {
        _currentView = View.FirstView;
        _perspectiveSwitcher = GetComponent<PerspectiveSwitcher>();
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        HandleRotation();

        if (Input.GetKeyDown(KeyCode.Q) && _canSwitch)
        {
            _canRotate = false;
            ChangeView();
        }
    }

    private void ChangeView()
    {
        _perspectiveSwitcher.SwitchPerspective();
        if (_camera.orthographic)
        {
            CanRotate(true);
            _firstWall.SetActive(false);
            _secondWall.SetActive(false);
        }
        else if (!_camera.orthographic)
        {
            float yRotation = GetYRotation();
            yRotation = yRotation > 180 ? yRotation - 360 : yRotation;

            if(yRotation <= 45 && yRotation >= -45)
            {
                _camera.transform.position = _firstTransform.position;
                _camera.transform.rotation = _firstTransform.rotation;
                _currentView = View.FirstView;
                _secondWall.SetActive(true);
            }
            else if(yRotation < -45 && yRotation >= -135)
            {
                _camera.transform.position = _secondTransform.position;
                _camera.transform.rotation = _secondTransform.rotation;
                _currentView = View.SecondView;
                _firstWall.SetActive(true);
            }
            else
            {
                _camera.transform.position = _firstTransform.position;
                _camera.transform.rotation = _firstTransform.rotation;
                _currentView = View.FirstView;

            }
        }
    }

    private void HandleRotation()
    {
        if(!_canRotate) return;
        if (Input.GetMouseButton(1))
        {
            if (!_canRotate) return;

            float mouseX = Input.GetAxis("Mouse X") * _rotateSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * _rotateSpeed;

            transform.RotateAround(_target.position, Vector3.up, mouseX);
            transform.RotateAround(_target.position, transform.right, -mouseY);
        }
    }

    public float GetYRotation()
    {
        return transform.rotation.eulerAngles.y;
    }

    public bool IsOrthographicView()
    {
        return _camera.orthographic;
    }

    public void CanRotate(bool canRotate)
    {
        _canRotate = canRotate;
    }

    public void CanSwitch(bool canSwitch)
    {
        _canSwitch = canSwitch;
    }
}
