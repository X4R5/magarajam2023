using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAudioSource : MonoBehaviour
{
    public static BGAudioSource Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
            return;
        }
    }
}
