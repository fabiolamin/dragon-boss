using UnityEngine;
using UnityEngine.UI;
public class MainMenuGUI : MonoBehaviour
{
    [SerializeField] private PlayGamesService _playGamesService;
    [SerializeField] private HeroSelection _heroSelection;
    [SerializeField] private GameObject _storePanel, _optionsPanel, _creditsPanel, _warningPanel;
    [SerializeField] private GameObject _spellStore, _heroesStore;
    [SerializeField] private GameObject _playerCoinsDisplay;
    [SerializeField] private Text _highScoreDisplay;
    [SerializeField] private Text _versionDisplay;
    [SerializeField] private Text _warningDisplay;
    [SerializeField] private GameObject _backButton;

    private void Start()
    {
        _versionDisplay.text = "Version " + Application.version;
        _playGamesService.WarningAuthentication += ActivateWarningPanel;
        _highScoreDisplay.text = GameDataController.Instance.GameData.HighScore.ToString();
    }

    public void ActivateOptionsPanel()
    {
        if (!SceneLoader.IsLoading)
        {
            _optionsPanel.SetActive(true);
            _backButton.SetActive(true);
        }
    }

    public void ActivateStorePanel()
    {
        if (!SceneLoader.IsLoading)
        {
            _storePanel.SetActive(true);
            _playerCoinsDisplay.SetActive(true);
            _backButton.SetActive(true);
            _heroSelection.ResetHeroes();
            _heroSelection.ShowHero(0);
        }
    }

    public void ActivateMainMenu()
    {
        _storePanel.SetActive(false);
        _optionsPanel.SetActive(false);
        _creditsPanel.SetActive(false);
        _playerCoinsDisplay.SetActive(false);
        _backButton.SetActive(false);
        _heroSelection.ShowSelectedHero();
    }

    public void ActivateSpellStore()
    {
        _heroesStore.SetActive(false);
        _spellStore.SetActive(true);
    }

    public void ActivateHeroesStore()
    {
        _heroesStore.SetActive(true);
        _spellStore.SetActive(false);
    }

    public void ActivateCreditsPanel()
    {
        _optionsPanel.SetActive(false);
        _creditsPanel.SetActive(true);
    }

    public void ActivateWarningPanel(string text)
    {
        _warningPanel.SetActive(true);
        _warningDisplay.text = text;
    }

    public void DeactivateWarningPanel()
    {
        _warningPanel.SetActive(false);
    }
}