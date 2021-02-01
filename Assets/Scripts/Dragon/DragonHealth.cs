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

        //Increase player's number of arenas
        //Increase game difficulty
        //Show the win screen
    }

    protected override void UpdateHealthDisplay()
    {
        _healthDisplay.text = _currentHealth.ToString();
    }
}
