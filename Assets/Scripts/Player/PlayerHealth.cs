using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    private ArenaMenu _arenaMenu;
    private PlayerInfo _playerInfo;
    [SerializeField] private Text _healthDisplay;

    private void Start()
    {
        _arenaMenu = FindObjectOfType<ArenaMenu>();
        _playerInfo = GetComponent<PlayerInfo>();
    }
    protected override void SetDeath()
    {
        _arenaMenu.ActivateGameOverPanel();
        _playerInfo.SaveArenas();
        gameObject.SetActive(false);
    }

    protected override void UpdateHealthDisplay()
    {
        _healthDisplay.text = _currentHealth.ToString();
    }

    public void RecoverHealth()
    {
        _currentHealth = health;
        UpdateHealthDisplay();
    }
}
