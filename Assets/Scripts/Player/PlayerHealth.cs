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
        _dragonManager.DragonDeath += RecoverHealth;
    }

    public override void SetDeath()
    {
        _playerInfo.Save();
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
        WasHit = true;
        _heroController.HeroAnimator.SetTrigger("Damage");
    }

    protected override void SetDeathAnimation()
    {
        _heroController.HeroAnimator.SetBool("IsAlive", IsAlive);
    }

    public void FinishDamage()
    {
        WasHit = false;
    }

    public bool IsHealthy()
    {
        return IsAlive && !WasHit;
    }
}
