using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] GameObject _videoObject;
    [SerializeField] TMP_Text _counterText;
    [SerializeField] float _timeToFinish = 100f;

    [SerializeField] GameObject _ilkCanvas, _evetCanvas, _hayirCanvas, _lastCanvas;

    bool _count = true;
    private void Update()
    {
        if (!_count) return;
        _timeToFinish -= Time.deltaTime;
        Debug.Log(_timeToFinish);

        if (_timeToFinish <= 0f)
        {
            _timeToFinish = 0f;
            ActivateLastCanvas();
            _count = false;
        }

        _counterText.text = "Yokedicinin harekete gecmesine kalan sure: " + Mathf.RoundToInt(_timeToFinish).ToString() + " saniye.";
    }

    public void ActivateEvetCanvas()
    {
        _ilkCanvas.SetActive(false);
        _hayirCanvas.SetActive(false);
        _evetCanvas.SetActive(true);
    }

    public void ActivateHayirCanvas()
    {
        _ilkCanvas.SetActive(false);
        _hayirCanvas.SetActive(true);
    }

    public void ActivateLastCanvas()
    {
        _evetCanvas.SetActive(false);
        _hayirCanvas.SetActive(false);
        _ilkCanvas.SetActive(false);
        _lastCanvas.SetActive(true);
        Invoke("Finish", 2f);
    }

    public void ShowVideo()
    {
<<<<<<< Updated upstream
=======
        BGAudioSource.Instance.CanPlay(false);
        BGAudioSource.Instance.GetComponent<AudioSource>().Stop();
>>>>>>> Stashed changes
        _videoObject.SetActive(true);
        Invoke("Finish", 2.3f);
        _count = false;
    }

    void Finish()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        BGAudioSource.Instance.CanPlay(true);
    }
}
