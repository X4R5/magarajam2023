using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    List<Sprite> _inventory = new List<Sprite>();
    [SerializeField] List<Image> _inventorySlots = new List<Image>();
    ItemUseLocation _currentItemUseLocation = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!Camera.main.orthographic) return;
        if (_currentItemUseLocation == null) return;
        if(!_currentItemUseLocation.CaUse()) return;
        if (!Input.anyKeyDown) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _currentItemUseLocation.UseItem(_inventory[0]);
            Debug.Log("Using item 1");
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _currentItemUseLocation.UseItem(_inventory[1]);
        }else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _currentItemUseLocation.UseItem(_inventory[2]);
        }else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _currentItemUseLocation.UseItem(_inventory[3]);
        }
    }

    public void CollectObject(Sprite icon)
    {
        _inventory.Add(icon);
        _inventorySlots[_inventory.Count - 1].sprite = icon;
        var color = _inventorySlots[_inventory.Count - 1].color;
        color.a = 1;
        _inventorySlots[_inventory.Count - 1].color = color;
    }

    internal void SetCurrentItemUseLocation(ItemUseLocation itemUseLocation)
    {
        _currentItemUseLocation = itemUseLocation;
        Debug.Log("Current item use location set");
    }

    public void HideCanvas()
    {
        GetComponent<Canvas>().enabled = false;
    }

    public void ShowCanvas()
    {
        GetComponent<Canvas>().enabled = true;
    }
}
