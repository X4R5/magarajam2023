using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MovableBox"))
        {
            Checklist.Instance.AddChecklistObject(this.gameObject);
        }
    }
}
