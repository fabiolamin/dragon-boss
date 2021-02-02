using UnityEngine;
using UnityEngine.UI;

public class ArenaMenu : MonoBehaviour
{
    private bool _isDelaying = false;
    private float _delayAux;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private float _delayToResume = 4f;
    [SerializeField] private Text _delayResumeDisplay;

    private void Awake()
    {
        _pauseMenu.SetActive(false);
        _delayResumeDisplay.gameObject.SetActive(false);
        _delayAux = _delayToResume;
    }

    private void Update()
    {
        if (_isDelaying)
        {
            StartResumeDelay();
        }
    }

    private void StartResumeDelay()
    {
        _delayToResume -= Time.unscaledDeltaTime;
        _delayResumeDisplay.text = ((int)_delayToResume).ToString();

        if (_delayToResume <= 0)
        {
            Resume();
        }
    }

    private void Resume()
    {
        Time.timeScale = 1;
        _delayResumeDisplay.gameObject.SetActive(false);
        _isDelaying = false;
        _delayToResume = _delayAux;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
    }

    public void SetResumeDelay()
    {
        _isDelaying = true;
        _pauseMenu.SetActive(false);
        _delayResumeDisplay.gameObject.SetActive(true);
    }
}
