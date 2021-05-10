using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ArenaMenuGUI : MonoBehaviour
{

    private bool _isDelaying = false;
    private float _delayAux;

    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private DragonManager _dragonManager;

    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private float _delayToResume = 4f;
    [SerializeField] private Text _delayResumeDisplay;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _exitWarningPanel;
    [SerializeField] private Text _scoreDisplay;
    [SerializeField] private Text _highScoreDisplay;
    [SerializeField] private Text _totalCoins;
    [SerializeField] private SceneLoader _sceneLoader;

    private void Awake()
    {
        Time.timeScale = 1;
        _delayAux = _delayToResume;
        _playerHealth.PlayerDeath += ActivateGameOverPanel;
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
        _pauseButton.SetActive(true);
        _delayResumeDisplay.gameObject.SetActive(false);
        _isDelaying = false;
        _delayToResume = _delayAux;
    }

    public void Pause()
    {
        if (!SceneLoader.IsLoading)
        {
            Time.timeScale = 0;
            _exitWarningPanel.SetActive(false);
            _pauseButton.SetActive(false);
            _pauseMenu.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        if (!SceneLoader.IsLoading)
            StartDelay(_pauseMenu);
    }

    private void StartDelay(GameObject panel)
    {
        _isDelaying = true;
        panel.SetActive(false);
        _delayResumeDisplay.gameObject.SetActive(true);
    }

    public void ActivateGameOverPanel()
    {
        MusicPlayer.Instance.PlayGameOverMusic();
        SetGameInfo();
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
    }

    private void SetGameInfo()
    {
        _scoreDisplay.text = (_dragonManager.CurrentDragon - 1).ToString();
        _highScoreDisplay.text = PlayerPrefs.GetInt("HighScore").ToString();
        _totalCoins.text = _playerInfo.Coins.ToString();
    }

    public void Restart()
    {
        MusicPlayer.Instance.PlayMainMusic();
        Time.timeScale = 1;
        _sceneLoader.RestartScene();
    }

    public void GoMainMenu()
    {
        if (_gameOverPanel.activeSelf)
        {
            MusicPlayer.Instance.PlayMainMusic();
        }

        _sceneLoader.LoadScene(0);
    }

    public void ActivateExitWarningPanel()
    {
        _pauseMenu.SetActive(false);
        _exitWarningPanel.SetActive(true);
    }
}
