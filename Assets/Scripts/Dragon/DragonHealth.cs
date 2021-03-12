using UnityEngine;
using UnityEngine.UI;
public class DragonHealth : Health
{
    [SerializeField] private Text _healthDisplay;

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
        _healthDisplay.text = _currentHealth.ToString();
    }

    public void IncreaseHealth(float amount)
    {
        health += amount;
        _currentHealth = health;
        UpdateHealthDisplay();
    }

    protected override void SetDamageAnimation()
    {
        animator.SetTrigger("Damage");
    }
}
