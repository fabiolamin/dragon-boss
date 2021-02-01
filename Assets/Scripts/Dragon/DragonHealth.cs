using System;
using UnityEngine;
using UnityEngine.UI;

public class DragonHealth : Health
{
    public delegate void DragonDeath();
    public static event DragonDeath OnDragonDeath;

    [SerializeField] private Text _healthDisplay;

    protected override void SetDeath()
    {
        OnDragonDeath.Invoke();
        gameObject.SetActive(false);

        //Increase player's number of arenas
        //Increase game difficulty
        //Set the win UI
    }

    protected override void UpdateHealthDisplay()
    {
        _healthDisplay.text = _currentHealth.ToString();
    }
}
