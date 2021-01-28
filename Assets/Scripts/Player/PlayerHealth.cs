using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [SerializeField] private Text _healthDisplay;

    private void Awake()
    {
        UpdateHealthDisplay();   
    }
    protected override void SetDeath()
    {
        Debug.Log("Player Dead!");
    }

    protected override void UpdateHealthDisplay()
    {
        _healthDisplay.text = health.ToString();
    }
}
