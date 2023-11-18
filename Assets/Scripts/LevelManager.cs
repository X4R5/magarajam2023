using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] GameObject _door;
    [SerializeField] AudioClip _doorOpenSound;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenDoor()
    {
        _door.GetComponent<Animator>().SetTrigger("Open");
        _door.GetComponent<BoxCollider>().isTrigger = true;
        _door.GetComponent<AudioSource>().PlayOneShot(_doorOpenSound);
    }
}
