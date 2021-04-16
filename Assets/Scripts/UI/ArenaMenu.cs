using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class ArenaMenu : MonoBehaviour
{
    private SpellHUD[] _spellHUDs;
    private PlayerInfo _playerInfo;
    private PlayerHealth _playerHealth;
    private DragonController _dragonController;
    private bool _isDelaying = false;
    private float _delayAux;

    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private float _delayToResume = 4f;
    [SerializeField] private Text _delayResumeDisplay;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Text _scoreDisplay;
    [SerializeField] private Text _highScoreDisplay;
    [SerializeField] private Text _totalCoins;
    [SerializeField] private SceneLoader _sceneLoader;

    [SerializeField] private AudioClip _gameOverClip;

    private void Awake()
    {
        Time.timeScale = 1;
        _spellHUDs = FindObjectsOfType<SpellHUD>();
        _playerInfo = FindObjectOfType<PlayerInfo>();
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _dragonController = FindObjectOfType<DragonController>();
        _pauseButton.SetActive(true);
        _pauseMenu.SetActive(false);
        _delayResumeDisplay.gameObject.SetActive(false);
        _gameOverPanel.SetActive(false);
        _delayAux = _delayToResume;
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
        _dragonController.CurrentDragonDisplay.SetActive(false);
        _playerInfo.PlayerCoinsDisplay.SetActive(false);
        _playerHealth.HealthDisplay.SetActive(false);
        _spellHUDs.ToList().ForEach(s => s.gameObject.SetActive(false));
    }

    private void SetGameInfo()
    {
        _scoreDisplay.text = (_dragonController.CurrentDragon - 1).ToString();
        _highScoreDisplay.text = PlayerPrefs.GetInt("HighScore").ToString();
        _totalCoins.text = _playerInfo.Coins.ToString();
    }

    public void Restart()
    {
        MusicPlayer.Instance.PlayMainMusic();
        Time.timeScale = 1;
        _sceneLoader.LoadScene(1);
    }

    public void GoMainMenu()
    {
        MusicPlayer.Instance.PlayMainMusic();
        _sceneLoader.LoadScene(0);
    }
}
