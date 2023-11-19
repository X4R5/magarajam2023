using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGAudioSource : MonoBehaviour
{
<<<<<<< Updated upstream
=======
    public static BGAudioSource Instance;
    bool _canPlay = true;
>>>>>>> Stashed changes
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
