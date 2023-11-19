using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1MessageTrigger : MonoBehaviour
{
    int count = 0;
    [SerializeField] GameObject _textObjectToShow;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.CompareTag("Player"))
        {
            count++;

            if(count >= 2)
            {
                _textObjectToShow.SetActive(true);
                Invoke("DisableTextObject", 5f);
            }
        }
    }

    void DisableTextObject()
    {
        _textObjectToShow.SetActive(false);
    }
}
