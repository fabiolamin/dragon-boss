using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArenaMenu : MonoBehaviour
{
    private DragonController _dragonController;
    private bool _isDelaying = false;
    private float _delayAux;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private float _delayToResume = 4f;
    [SerializeField] private Text _delayResumeDisplay;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _currentDragonDisplay;
    [SerializeField] private Text _defeatedDragons;
    [SerializeField] private Text _maxDefeatedDragons;

    private void Awake()
    {
        _dragonController = FindObjectOfType<DragonController>();
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
        _currentDragonDisplay.SetActive(false);
        _defeatedDragons.text = "Dragons Defeated: " + (_dragonController.CurrentDragon - 1);
        _maxDefeatedDragons.text = "Max Dragons Defeated: " + PlayerPrefs.GetInt("MaxDragon");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
