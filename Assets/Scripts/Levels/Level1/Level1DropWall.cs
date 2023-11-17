using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level1DropWall : MonoBehaviour
{
    int _count = 0;
    [SerializeField] TMP_Text _text;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _count++;
        }

        if (_count == 2)
        {
            _text.gameObject.SetActive(true);
            Invoke("DisableText", 2f);
        }
    }
    
    void DisableText()
    {
        _text.gameObject.SetActive(false);
    }

}
