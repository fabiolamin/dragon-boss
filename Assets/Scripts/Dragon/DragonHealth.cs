using UnityEngine;
using UnityEngine.UI;

public class DragonHealth : Health
{
    [SerializeField] private Text _healthDisplay;

    protected override void SetDeath()
    {
        Debug.Log("Dragon Dead!");
    }

    protected override void UpdateHealthDisplay()
    {
        _healthDisplay.text = _currentHealth.ToString();
    }
}
