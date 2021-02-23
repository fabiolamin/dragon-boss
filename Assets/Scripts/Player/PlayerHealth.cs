using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : Health
{
    private ArenaMenu _arenaMenu;
    private PlayerInfo _playerInfo;
    [SerializeField] private Text _healthDisplay;

    public GameObject HealthDisplay { get { return _healthDisplay.gameObject; } }

    private void Start()
    {
        _arenaMenu = FindObjectOfType<ArenaMenu>();
        _playerInfo = GetComponent<PlayerInfo>();
        DragonController.DragonDeathHandler += RecoverHealth;
    }
    protected override void SetDeath()
    {
        _playerInfo.SaveHighScore();
        _arenaMenu.ActivateGameOverPanel();
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
