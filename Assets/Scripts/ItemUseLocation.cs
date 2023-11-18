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
    AudioSource _audioSource;
    [SerializeField] AudioClip _useAudio, _wrongAudio;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

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
        if (sprite == _expectedIcon)
        {
            _audioSource.PlayOneShot(_useAudio);
            _gameObjectToActivate.SetActive(true);
            Checklist.Instance.AddChecklistObject(gameObject);
            _used = true;
        }
        else
        {
            _audioSource.PlayOneShot(_wrongAudio);
        }
    }
}
