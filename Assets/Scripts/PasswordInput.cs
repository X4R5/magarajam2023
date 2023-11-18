using TMPro;
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

    RobotController _robotController;

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
                Checklist.Instance.AddChecklistObject(gameObject);
                if(_gameObjectToActivateOnComplete != null) _gameObjectToActivateOnComplete.SetActive(true);
                DisableCanvas();
                return;
            }

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
        _canvas.SetActive(true);
        ClearPassword();
        _robotController.DisableMovement();
    }

    public void DisableCanvas()
    {
        _canvas.SetActive(false);
        _robotController.EnableMovement();
    }

    public bool IsCanvasEnabled()
    {
        return _canvas.activeSelf;
    }
}
