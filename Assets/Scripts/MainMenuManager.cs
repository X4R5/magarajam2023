using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    Animator _crossFade;

    private void Awake()
    {
        _crossFade = GameObject.Find("CrossFade").GetComponent<Animator>();
    }

    public void PlayBtn()
    {
        StartCoroutine(LoadNextScene());
    }

    public void QuitBtn()
    {
        StartCoroutine(Quit());
    }

    IEnumerator LoadNextScene()
    {
        _crossFade.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Quit()
    {
        _crossFade.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }
}
