using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerHealth : Health
{
    [SerializeField] private ArenaMenuGUI _arenaMenuGUI;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private HeroController _heroController;
    [SerializeField] private DragonManager _dragonManager;
    [SerializeField] private Text _healthDisplay;

    public delegate void PlayerDeathHandler();
    public event PlayerDeathHandler PlayerDeath;

    public GameObject HealthDisplay { get { return _healthDisplay.gameObject; } }
    public bool WasHit { get; set; } = false;

    private void Start()
    {
        animator = _heroController.HeroAnimator;
        _dragonManager.DragonDeath += RecoverHealth;
    }

    public override void SetDeath()
    {
        _playerInfo.SaveHighScore();
        PlayerDeath?.Invoke();
        gameObject.SetActive(false);
    }

    protected override void UpdateHealthDisplay()
    {
        _healthDisplay.text = currentHealth.ToString();
    }

    public void RecoverHealth()
    {
        if (IsAlive)
        {
            currentHealth = healthData.Health;
            UpdateHealthDisplay();
        }
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
