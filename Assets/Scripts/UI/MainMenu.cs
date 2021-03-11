using UnityEngine;
public class MainMenu : MonoBehaviour
{
    private AudioController _audioController;
    [SerializeField] private GameObject _storePanel, _optionsPanel;
    [SerializeField] private GameObject _spellStore, _heroesStore;
    [SerializeField] private GameObject _playerCoinsDisplay;
    [SerializeField] private GameObject _backButton;

    private void Awake()
    {
        _audioController = FindObjectOfType<AudioController>();
        _storePanel.SetActive(false);
        _optionsPanel.SetActive(false);
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
        }
    }

    public void ActivateMainMenu()
    {
        _storePanel.SetActive(false);
        _optionsPanel.SetActive(false);
        _playerCoinsDisplay.SetActive(false);
        _backButton.SetActive(false);
        _audioController.UpdateAudioVolume();
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
}
