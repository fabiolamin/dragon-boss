using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [SerializeField] private Text _healthDisplay;

    private void Start()
    {
        UpdateHealthDisplay();   
    }
    protected override void SetDeath()
    {
        Debug.Log("Player Dead!");
    }

    protected override void UpdateHealthDisplay()
    {
        _healthDisplay.text = _currentHealth.ToString();
    }
}
