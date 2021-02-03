using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArenaMenu : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private PlayerInfo _playerInfo;
    private DragonController _dragonController;
    private bool _isDelaying = false;
    private float _delayAux;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private float _delayToResume = 4f;
    [SerializeField] private float _delayToNextArena = 3f;
    [SerializeField] private Text _delayResumeDisplay;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Text _nextArenaText;
    [SerializeField] private GameObject _playerArenasDisplay;
    [SerializeField] private Text _wonArenas;

    private void Awake()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _playerInfo = FindObjectOfType<PlayerInfo>();
        _dragonController = FindObjectOfType<DragonController>();
        _pauseMenu.SetActive(false);
        _delayResumeDisplay.gameObject.SetActive(false);
        _winPanel.SetActive(false);
        _gameOverPanel.SetActive(false);
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
        _nextArenaText.text = "Go to Arena " + _playerInfo.WonArenas + "!";
        _winPanel.SetActive(true);
        _playerArenasDisplay.SetActive(false);
    }

    public void StartNextArena()
    {
        StartDelay(_winPanel);
        _playerHealth.RecoverHealth();
        _dragonController.ActiveRandomDragon();
        _playerArenasDisplay.SetActive(true);
    }

    private void StartDelay(GameObject panel)
    {
        _isDelaying = true;
        panel.SetActive(false);
        _delayResumeDisplay.gameObject.SetActive(true);
    }

    public void ActivateGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        _playerArenasDisplay.SetActive(false);
        _wonArenas.text = "Arenas Won: " + (_playerInfo.WonArenas - 1).ToString();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
