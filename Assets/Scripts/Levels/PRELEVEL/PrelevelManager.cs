using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrelevelManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _pages = new List<GameObject>();
    [SerializeField] GameObject _pressSpaceText;
    bool _canPressSpace = false;
    int _currentPage = 0;
    Animator _crossFadeAnimator;
    [SerializeField] float _timeToWait = 2f;

    private void Awake()
    {
        _crossFadeAnimator = GameObject.Find("CrossFade").GetComponent<Animator>();
        Invoke("ShowPressSpaceText", _timeToWait);
    }

    private void Start()
    {
        _pages[_currentPage].SetActive(true);
    }

    private void Update()
    {
        if (!_canPressSpace) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentPage == _pages.Count - 1)
            {
                _pressSpaceText.SetActive(false);
                _canPressSpace = false;
                StartCoroutine(LoadNextScene());
            }
            else
            {
                NextPage();
                _pressSpaceText.SetActive(false);
                _canPressSpace = false;
                Invoke("ShowPressSpaceText", _timeToWait);
            }
        }
    }

    public void NextPage()
    {
        _pages[_currentPage].SetActive(false);
        _currentPage++;
        _pages[_currentPage].SetActive(true);
    }

    void ShowPressSpaceText()
    {
        _pressSpaceText.SetActive(true);
        _canPressSpace = true;
    }

    IEnumerator LoadNextScene()
    {
        _crossFadeAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
