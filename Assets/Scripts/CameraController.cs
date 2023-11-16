using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform _target;
    public float _rotateSpeed = 2.0f;
    bool _canRotate = false;

    [SerializeField] Transform _firstTransform, _secondTransform;
    [SerializeField] GameObject _firstWall, _secondWall;
    public enum View
    {
        FirstView,
        SecondView
    }

    public View _currentView;

    private void Start()
    {
        _currentView = View.FirstView;
    }

    void Update()
    {
        HandleRotation();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeView();
        }
    }

    private void ChangeView()
    {
        if (Camera.main.orthographic)
        {
            Camera.main.orthographic = false;
            _canRotate = true;
            _firstWall.SetActive(false);
            _secondWall.SetActive(false);
        }
        else if (!Camera.main.orthographic)
        {
            float yRotation = GetYRotation();
            yRotation = yRotation > 180 ? yRotation - 360 : yRotation;

            if(yRotation <= 45 && yRotation >= -45)
            {
                Camera.main.transform.position = _firstTransform.position;
                Camera.main.transform.rotation = _firstTransform.rotation;
                _currentView = View.FirstView;
                _secondWall.SetActive(true);
            }
            else if(yRotation < -45 && yRotation >= -135)
            {
                Camera.main.transform.position = _secondTransform.position;
                Camera.main.transform.rotation = _secondTransform.rotation;
                _currentView = View.SecondView;
                _firstWall.SetActive(true);
            }
            else
            {
                Camera.main.transform.position = _firstTransform.position;
                Camera.main.transform.rotation = _firstTransform.rotation;
                _currentView = View.FirstView;

            }

            Camera.main.orthographic = true;
            _canRotate = false;
        }
    }

    private void HandleRotation()
    {
        if(!_canRotate) return;
        if (Input.GetMouseButton(1))
        {
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
        return Camera.main.orthographic;
    }
}
