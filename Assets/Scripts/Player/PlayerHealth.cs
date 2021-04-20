using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerHealth : Health
{
    private ArenaMenuGUI _arenaMenuGUI;
    private Player _player;
    private PlayerInfo _playerInfo;
    private HeroController _heroController;
    [SerializeField] private Text _healthDisplay;

    public GameObject HealthDisplay { get { return _healthDisplay.gameObject; } }
    public bool WasHit { get; set; } = false;

    private void Start()
    {
        _arenaMenuGUI = FindObjectOfType<ArenaMenuGUI>();
        _player = GetComponent<Player>();
        _playerInfo = GetComponent<PlayerInfo>();
        _heroController = GetComponent<HeroController>();
        animator = _heroController.HeroAnimator;
        DragonController.DragonDeathHandler += RecoverHealth;
    }
    protected override void SetDeath()
    {
        _playerInfo.SaveHighScore();
        _arenaMenuGUI.ActivateGameOverPanel();
        gameObject.SetActive(false);
    }

    protected override void UpdateHealthDisplay()
    {
        _healthDisplay.text = _currentHealth.ToString();
    }

    public void RecoverHealth()
    {
        _currentHealth = healthData.Health;
        UpdateHealthDisplay();
    }

    protected override void SetDamageAnimation()
    {
        StartCoroutine(SetPlayerDamageAnimation());
    }

    private IEnumerator SetPlayerDamageAnimation()
    {
        WasHit = true;
        animator.SetTrigger("Damage");
        yield return new WaitForSeconds(_player.PlayerData.DelayFinishDamage);
        WasHit = false;
    }

    public bool IsHealthy()
    {
        return IsAlive && !WasHit;
    }
}
