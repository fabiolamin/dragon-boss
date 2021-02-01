using System;
using UnityEngine;
using UnityEngine.UI;

public class DragonHealth : Health
{
    [SerializeField] private Text _healthDisplay;

    protected override void SetDeath()
    {
        gameObject.SetActive(false);
        DragonController.OnDragonDeath();

        //Set the win UI
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
}
