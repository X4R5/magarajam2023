using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCube : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Collided with platform");
            Debug.Log(gameObject.name);
            Checklist.Instance.AddChecklistObject(this.gameObject);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Checklist.Instance.RemoveChecklistObject(this.gameObject);
        }
    }
}
