using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordScreen : MonoBehaviour
{
    bool _canInteract = false;
    RobotController _robotController;

    private void Update()
    {
        if (!_canInteract) return;
        if (!Camera.main.orthographic) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            PasswordInput.Instance.EnableCanvas();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Triggered");
            _canInteract = true;
            _robotController = other.GetComponent<RobotController>();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canInteract = false;
        }
    }
}
