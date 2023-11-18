using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Platform : MonoBehaviour
{
    [SerializeField] GameObject _doorToOpen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MovableBox"))
        {
            Checklist.Instance.AddChecklistObject(gameObject);
            _doorToOpen.GetComponent<Animator>().SetTrigger("Level5Open");
        }
    }
}
