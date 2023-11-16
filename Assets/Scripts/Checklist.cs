using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Checklist : MonoBehaviour
{
    public static Checklist Instance;
    [SerializeField] int _checklistCount;
    List<GameObject> _checklistObjects = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void AddChecklistObject(GameObject checklistObject)
    {
        _checklistObjects.Add(checklistObject);
        CheckCount();
    }

    public void RemoveChecklistObject(GameObject checklistObject)
    {
        _checklistObjects.Remove(checklistObject);
    }

    private void CheckCount()
    {
        if (_checklistObjects.Count == _checklistCount)
        {
            LevelManager.Instance.OpenDoor();
        }
    }
}
