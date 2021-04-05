using UnityEngine;
public class MainMenu : MonoBehaviour
{
    private AudioController _audioController;
    private HeroSelection _heroSelection;
    [SerializeField] private GameObject _storePanel, _optionsPanel, _creditsPanel;
    [SerializeField] private GameObject _spellStore, _heroesStore;
    [SerializeField] private GameObject _playerCoinsDisplay;
    [SerializeField] private GameObject _backButton;

    private void Start()
    {
        _audioController = FindObjectOfType<AudioController>();
        _heroSelection = FindObjectOfType<HeroSelection>();
        _storePanel.SetActive(false);
        _optionsPanel.SetActive(false);
        _creditsPanel.SetActive(false);
        _spellStore.SetActive(true);
        _heroesStore.SetActive(false);
        _playerCoinsDisplay.SetActive(false);
        _backButton.SetActive(false);
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
        _audioController.UpdateAudioVolume();
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
