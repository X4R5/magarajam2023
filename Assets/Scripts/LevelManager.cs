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

<<<<<<< Updated upstream
=======
    private void Update()
    {
        if (_isSceneLoading) return;

        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            if (SceneManager.GetActiveScene().buildIndex == 9) return;
            StartCoroutine(LoadNextScene());
        }

        if(Input.GetKeyDown(KeyCode.PageDown))
        {
            if (SceneManager.GetActiveScene().buildIndex == 2) return;
            StartCoroutine(LoadPreviousScene());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(RestartLevel());
        }
    }
>>>>>>> Stashed changes
    public void OpenDoor()
    {
        _door.GetComponent<Animator>().SetTrigger("Open");
        _door.GetComponent<BoxCollider>().isTrigger = true;
        _door.GetComponent<AudioSource>().PlayOneShot(_doorOpenSound);
    }
<<<<<<< Updated upstream
=======

    IEnumerator LoadNextScene()
    {
        _isSceneLoading = true;
        _crossFadeAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LoadPreviousScene()
    {
        
        _isSceneLoading = true;
        _crossFadeAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    IEnumerator RestartLevel()
    {
        _isSceneLoading = true;
        _crossFadeAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
>>>>>>> Stashed changes
}
