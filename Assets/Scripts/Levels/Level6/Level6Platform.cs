using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6Platform : MonoBehaviour
{
    [SerializeField] GameObject _expectedObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _expectedObject)
        {
            Checklist.Instance.AddChecklistObject(gameObject);
        }
    }
}
