using UnityEngine;
using UnityEngine.UI;

public class DragonHealth : Health
{
    [SerializeField] private Text _healthDisplay;

    private void Awake()
    {
        UpdateHealthDisplay();
    }
    protected override void SetDeath()
    {
        Debug.Log("Dragon Dead!");
    }

    protected override void UpdateHealthDisplay()
    {
        _healthDisplay.text = health.ToString();
    }
}
