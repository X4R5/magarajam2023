using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAudioSource : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
