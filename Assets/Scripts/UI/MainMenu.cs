using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _storePanel;
    [SerializeField] private GameObject _playerCoinsDisplay;

    private void Awake()
    {
        _storePanel.SetActive(false);
        _playerCoinsDisplay.SetActive(false);
    }

    public void ActivateStorePanel()
    {
        _storePanel.SetActive(true);
        _playerCoinsDisplay.SetActive(true);
    }

    public void ActivateMainMenu()
    {
        _storePanel.SetActive(false);
        _playerCoinsDisplay.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
