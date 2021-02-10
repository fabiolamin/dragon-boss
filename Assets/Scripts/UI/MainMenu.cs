using UnityEngine;
public class MainMenu : MonoBehaviour
{
    private AudioController _audioController;
    [SerializeField] private GameObject _storePanel, _optionsPanel;
    [SerializeField] private GameObject _playerCoinsDisplay;
    [SerializeField] private GameObject _backButton;

    private void Awake()
    {
        _audioController = FindObjectOfType<AudioController>();
        _storePanel.SetActive(false);
        _optionsPanel.SetActive(false);
        _playerCoinsDisplay.SetActive(false);
        _backButton.SetActive(false);
    }

    public void ActivateOptionsPanel()
    {
        _optionsPanel.SetActive(true);
        _backButton.SetActive(true);
    }

    public void ActivateStorePanel()
    {
        _storePanel.SetActive(true);
        _playerCoinsDisplay.SetActive(true);
        _backButton.SetActive(true);
    }

    public void ActivateMainMenu()
    {
        _storePanel.SetActive(false);
        _optionsPanel.SetActive(false);
        _playerCoinsDisplay.SetActive(false);
        _backButton.SetActive(false);
        _audioController.UpdateAudioVolume();
    }
}
