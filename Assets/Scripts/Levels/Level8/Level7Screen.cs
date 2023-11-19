using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7Screen : MonoBehaviour
{
    [SerializeField] GameObject _endGameCanvas;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _endGameCanvas.SetActive(true);
            other.GetComponent<RobotController>().DisableMovement();
            Camera.main.GetComponent<CameraController>().CanSwitch(false);
        }
    }
}
