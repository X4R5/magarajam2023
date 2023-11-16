using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] GameObject _door;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenDoor()
    {
        _door.GetComponent<Animator>().SetTrigger("Open");
    }
}
