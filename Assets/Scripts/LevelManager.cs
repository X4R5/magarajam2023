using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] GameObject _door;
    [SerializeField] AudioClip _doorOpenSound;
    [SerializeField] Animator _crossFadeAnimator;
    bool _isSceneLoading = false;

    private void Awake()
    {
        Instance = this;
        _crossFadeAnimator = GameObject.Find("CrossFade").GetComponent<Animator>();
    }

    private void Update()
    {
        if (_isSceneLoading) return;

        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            if (SceneManager.GetActiveScene().buildIndex == 7) return;
            StartCoroutine(LoadNextScene());
        }

        if(Input.GetKeyDown(KeyCode.PageDown))
        {
            if (SceneManager.GetActiveScene().buildIndex == 1) return;
            StartCoroutine(LoadPreviousScene());
        }
    }
    public void OpenDoor()
    {
        _door.GetComponent<Animator>().SetTrigger("Open");
        _door.GetComponent<BoxCollider>().isTrigger = true;
        _door.GetComponent<AudioSource>().PlayOneShot(_doorOpenSound);
    }

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
}
