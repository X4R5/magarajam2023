using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGAudioSource : MonoBehaviour
{
    public static BGAudioSource Instance;
    bool _canPlay = true;
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

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            GetComponent<AudioSource>().Stop();
        }
        else
        {
            if (!GetComponent<AudioSource>().isPlaying && _canPlay)
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }

    public void CanPlay(bool canPlay)
    {
        _canPlay = canPlay;
    }

}
