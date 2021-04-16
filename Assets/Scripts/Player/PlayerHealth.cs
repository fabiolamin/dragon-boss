using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerHealth : Health
{
    private ArenaMenu _arenaMenu;
    private PlayerInfo _playerInfo;
    private HeroController _heroController;
    [SerializeField] private Text _healthDisplay;
    [SerializeField] private float _delayFinishDamage = 0.5f;

    public GameObject HealthDisplay { get { return _healthDisplay.gameObject; } }
    public bool WasHit { get; set; } = false;

    private void Start()
    {
        _arenaMenu = FindObjectOfType<ArenaMenu>();
        _playerInfo = GetComponent<PlayerInfo>();
        _heroController = GetComponent<HeroController>();
        animator = _heroController.HeroAnimator;
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

    protected override void SetDamageAnimation()
    {
        StartCoroutine(SetPlayerDamageAnimation());
    }

    private IEnumerator SetPlayerDamageAnimation()
    {
        WasHit = true;
        animator.SetTrigger("Damage");
        yield return new WaitForSeconds(_delayFinishDamage);
        WasHit = false;
    }

    public bool IsHealthy()
    {
        return IsAlive && !WasHit;
    }
}
