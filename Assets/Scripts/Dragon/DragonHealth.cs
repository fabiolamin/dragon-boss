using UnityEngine;
using UnityEngine.UI;

public class DragonHealth : Health
{
    [SerializeField] private Text _healthDisplay;

    private void Start()
    {
        UpdateHealthDisplay();
    }
    protected override void SetDeath()
    {
        Debug.Log("Dragon Dead!");
    }

    protected override void UpdateHealthDisplay()
    {
        _healthDisplay.text = _currentHealth.ToString();
    }
}
