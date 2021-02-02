using UnityEngine;
using UnityEngine.UI;

public class ArenaMenu : MonoBehaviour
{
    private DragonController _dragonController;
    private bool _isDelaying = false;
    private float _delayAux;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private float _delayToResume = 4f;
    [SerializeField] private float _delayToNextArena = 3f;
    [SerializeField] private Text _delayResumeDisplay;
    [SerializeField] private GameObject _winPanel;

    private void Awake()
    {
        _dragonController = FindObjectOfType<DragonController>();
        _pauseMenu.SetActive(false);
        _delayResumeDisplay.gameObject.SetActive(false);
        _winPanel.SetActive(false);
        _delayAux = _delayToResume;
        DragonController.DragonDeathHandler += ActivateWinPanel;
    }

    private void Update()
    {
        if (_isDelaying)
        {
            Delay();
        }
    }

    private void Delay()
    {
        _delayToResume -= Time.unscaledDeltaTime;
        _delayResumeDisplay.text = ((int)_delayToResume).ToString();

        if (_delayToResume <= 0)
        {
            FinishDelay();
        }
    }

    private void FinishDelay()
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

    public void ResumeGame()
    {
        StartDelay(_pauseMenu);
    }

    public void ActivateWinPanel()
    {
        Time.timeScale = 0;
        _winPanel.SetActive(true);
    }

    public void StartNextArena()
    {
        StartDelay(_winPanel);
        _dragonController.ActiveRandomDragon();
    }

    private void StartDelay(GameObject panel)
    {
        _isDelaying = true;
        panel.SetActive(false);
        _delayResumeDisplay.gameObject.SetActive(true);
    }
}
