using UnityEngine;
using UnityEngine.UI;
public class MainMenuGUI : MonoBehaviour
{
    [SerializeField] private HeroSelection _heroSelection;
    [SerializeField] private GameObject _storePanel, _optionsPanel, _creditsPanel;
    [SerializeField] private GameObject _spellStore, _heroesStore;
    [SerializeField] private GameObject _playerCoinsDisplay;
    [SerializeField] private Text _highScoreDisplay;
    [SerializeField] private Text _versionDisplay;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private Slider _musicSlider, _soundsSlider;

    private void Start()
    {
        _highScoreDisplay.text = PlayerPrefs.GetInt("HighScore").ToString();
        _versionDisplay.text = "Version " + Application.version;
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
}