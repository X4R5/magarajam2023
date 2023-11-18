using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUseLocation : MonoBehaviour
{
    [SerializeField] Sprite _expectedIcon;
    bool _canUse = false;
    bool _used = false;
    [SerializeField] GameObject _gameObjectToActivate = null;

    private void OnTriggerStay(Collider other)
    {
        if (_used) return;
        if (other.CompareTag("Player"))
        {
            _canUse = true;
            InventoryManager.Instance.SetCurrentItemUseLocation(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_used) return;
        if (other.CompareTag("Player"))
        {
            _canUse = false;
        }
    }

    public bool CaUse()
    {
        return _canUse;
    }

    internal void UseItem(Sprite sprite)
    {
        Debug.Log("Using item");
        if (sprite == _expectedIcon)
        {
            _gameObjectToActivate.SetActive(true);
            Checklist.Instance.AddChecklistObject(gameObject);
            _used = true;
        }
        else
        {
            Debug.Log("Wrong item");
        }
    }
}
