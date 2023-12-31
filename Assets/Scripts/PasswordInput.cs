﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordInput : MonoBehaviour
{
    public static PasswordInput Instance;

    [SerializeField] TMP_Text[] _passwordTextFields;
    [SerializeField] Button[] _numberButtons;
    [SerializeField] Button _enterButton;
    [SerializeField] Button _clearButton;
    [SerializeField] GameObject _canvas;
    [SerializeField] GameObject _gameObjectToActivateOnComplete = null;

    const int _passwordLength = 4;
    [SerializeField] string _correctPassword = "1234";
    string _enteredPassword = "";

    [SerializeField] AudioClip _correctAudio, _wrongAudio, _typeAudio;
    AudioSource _audioSource;
    RobotController _robotController;

    bool _completed = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        _robotController = GameObject.FindGameObjectWithTag("Player").GetComponent<RobotController>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _enterButton.onClick.AddListener(CheckPassword);
        _clearButton.onClick.AddListener(ClearPassword);

        for (int i = 0; i < _numberButtons.Length; i++)
        {
            int number = i + 1;
            if(i < 9)
            {
                _numberButtons[i].onClick.AddListener(() => AddNumber(number));
                _numberButtons[i].GetComponentInChildren<TMP_Text>().text = number.ToString();
            }
            else
            {
                number = 0;
                _numberButtons[i].onClick.AddListener(() => AddNumber(number));
                _numberButtons[i].GetComponentInChildren<TMP_Text>().text = "0";
            }
        }

        UpdatePasswordTextFields();
    }

    private void Update()
    {
        if (!_canvas.activeSelf) return;
        if (!Camera.main.orthographic) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DisableCanvas();
        }
    }

    private void AddNumber(int number)
    {
        _enteredPassword += number.ToString();
        UpdatePasswordTextFields();
        _audioSource.PlayOneShot(_typeAudio);

        if (_enteredPassword.Length == _passwordLength)
        {
            CheckPassword();
        }
    }

    private void CheckPassword()
    {
        if (_enteredPassword.Length == _passwordLength)
        {
            if (_enteredPassword == _correctPassword)
            {
                _completed = true;
                _audioSource.PlayOneShot(_correctAudio);
                Checklist.Instance.AddChecklistObject(gameObject);
                if(_gameObjectToActivateOnComplete != null) _gameObjectToActivateOnComplete.SetActive(true);
                DisableCanvas();
                return;
            }

            _audioSource.PlayOneShot(_wrongAudio);
            _enteredPassword = "";
            UpdatePasswordTextFields();
        }
    }

    private void UpdatePasswordTextFields()
    {
        for (int i = 0; i < _passwordTextFields.Length; i++)
        {
            if (i < _enteredPassword.Length)
            {
                _passwordTextFields[i].text = _enteredPassword[i].ToString();
            }
            else
            {
                _passwordTextFields[i].text = "*";
            }
        }
    }

    void ClearPassword()
    {
        _enteredPassword = "";
        UpdatePasswordTextFields();
    }

    public void EnableCanvas()
    {
        if (_completed) return;
        _canvas.SetActive(true);
        ClearPassword();
        _robotController.DisableMovement();
        Camera.main.GetComponent<CameraController>().CanSwitch(false);
    }

    public void DisableCanvas()
    {
        _canvas.SetActive(false);
        _robotController.EnableMovement();
        Camera.main.GetComponent<CameraController>().CanSwitch(true);
    }

    public bool IsCanvasEnabled()
    {
        return _canvas.activeSelf;
    }
}
