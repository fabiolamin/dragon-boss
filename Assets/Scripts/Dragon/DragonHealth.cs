using UnityEngine;
using UnityEngine.UI;
public class DragonHealth : Health
{
    [SerializeField] private Image _healthBarDisplay;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected override void SetDeath()
    {
        gameObject.SetActive(false);
        DragonController.OnDragonDeath();
    }

    protected override void UpdateHealthDisplay()
    {
        _healthBarDisplay.fillAmount = _currentHealth / healthData.Health;
    }

    public void IncreaseHealth(float amount)
    {
        healthData.Health += amount;
        _currentHealth = healthData.Health;
        UpdateHealthDisplay();
    }

    protected override void SetDamageAnimation()
    {
        animator.SetTrigger("Damage");
    }
}
